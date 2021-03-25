using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {

	public float speed = 10.0f;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (Vector3.up, speed * Time.deltaTime);	//turn view to right
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (Vector3.down, speed * Time.deltaTime); //turn view to left
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Rotate (Vector3.left, 0.5f * speed * Time.deltaTime); //tilt view Up
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Rotate (Vector3.right, 0.5f * speed * Time.deltaTime);
		}
	}
}
