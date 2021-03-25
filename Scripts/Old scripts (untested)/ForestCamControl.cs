using UnityEngine;
using System.Collections;

public class ForestCamControl : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;

	void Start(){
		player = GameObject.Find ("player");
	}

	void Update()
	{
		offset = transform.position - player.transform.position;
	}
	void LateUpdate ()
	{
		transform.position = player.transform.position;
		//Untoggle script below to use arrows to rotate the camera left/right (does not use physics engine)
//		if(Input.GetKey(KeyCode.LeftArrow))
//		{
//			transform.RotateAround(player.transform.position, Vector3.up, -50 * Time.deltaTime);
//			offset = transform.position - player.transform.position;
//		}
//		
//		if (Input.GetKey(KeyCode.RightArrow))
//		{
//			transform.RotateAround(player.transform.position, Vector3.up, 50 * Time.deltaTime);
//			offset = transform.position - player.transform.position;
//		}
	}

}