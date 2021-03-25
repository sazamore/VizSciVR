using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed = 10.0f;
	
	public Rigidbody rb;

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal")*speed;
		float moveVertical = Input.GetAxis ("Vertical") * speed;

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
//		rb.AddForce (movement);
		rb.GetComponent<Rigidbody>().AddForce(movement);
		//transform.Translate (movement)
	}
}