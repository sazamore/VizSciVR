﻿using UnityEngine;
using System.IO;
using System;

public class Player : MonoBehaviour {

	public PipeSystem pipeSystem;
	
	public float velocity;
	public float rotationVelocity;

	private Pipe currentPipe;

	private float distanceTraveled;
	private float deltaToRotation;
	private float systemRotation;
	private float worldRotation, avatarRotation;

	private Transform world, rotater;


	private void Start () {
		//Make save file + header
		File.AppendAllText("testText2.txt",Environment.NewLine + "Cam pos (x,y,z), Z-Angle rotation (degrees), Velocity = " + velocity.ToString () + Environment.NewLine);

		world = pipeSystem.transform.parent;
		rotater = transform.GetChild(0);
		currentPipe = pipeSystem.SetupFirstPipe();
		SetupCurrentPipe();
	}

	private void Update () {
		float delta = velocity * Time.deltaTime;
		distanceTraveled += delta;
		systemRotation += delta * deltaToRotation;

		if (systemRotation >= currentPipe.CurveAngle) {
			delta = (systemRotation - currentPipe.CurveAngle) / deltaToRotation;
			currentPipe = pipeSystem.SetupNextPipe();
			SetupCurrentPipe();
			systemRotation = delta * deltaToRotation;
		}

		pipeSystem.transform.localRotation =
			Quaternion.Euler(0f, 0f, systemRotation);

		//output system position
		File.AppendAllText("testText2.txt",pipeSystem.transform.position.ToString("F3") + ", ");
		Debug.Log (worldRotation);
		File.AppendAllText("testText2.txt","("+ worldRotation.ToString() + ", 0, " + systemRotation.ToString() + ")" + Environment.NewLine);

		UpdateAvatarRotation();
		if (Input.GetKey("down")) {
			if (currentPipe.arrayPos >= currentPipe.array.Length - 1) {
				currentPipe.arrayPos = 0;
			} else {
				currentPipe.arrayPos += 1;
			}
		}

	}

	private void UpdateAvatarRotation () {
		avatarRotation +=
			rotationVelocity * Time.deltaTime * Input.GetAxis("Horizontal");
		if (avatarRotation < 0f) {
			avatarRotation += 360f;
		}
		else if (avatarRotation >= 360f) {
			avatarRotation -= 360f;
		}
		rotater.localRotation = Quaternion.Euler(avatarRotation, 0f, 0f);
	}

	private void SetupCurrentPipe () {
		deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.CurveRadius);
		worldRotation += currentPipe.RelativeRotation;
		if (worldRotation < 0f) {
			worldRotation += 360f;
		}
		else if (worldRotation >= 360f) {
			worldRotation -= 360f;
		}
		world.localRotation = Quaternion.Euler(worldRotation, 0f, 0f);

	}
}