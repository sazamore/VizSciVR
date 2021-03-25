using UnityEngine;
using System.Collections;

public class CamMove : MonoBehaviour {
	void Start () {
	}
	
	void Update () {
	}
	
	public void Move () {
		Vector3 moveVector = new Vector3(10, 0, 0);
		transform.Translate(moveVector);
		//look at target
	}
}