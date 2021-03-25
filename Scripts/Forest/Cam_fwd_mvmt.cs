using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_fwd_mvmt : MonoBehaviour
{
    //movement speed in units per second
    public float movementSpeed = 5f;
    public float rotationSpeed = 5f;

    void Update()
    {
    	//Key Press (arrows):
        //get the Input from Horizontal axis 
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //rotate the view
        transform.Rotate(verticalInput * rotationSpeed * Time.deltaTime, horizontalInput * rotationSpeed * Time.deltaTime,0);

        //update the position
        transform.Translate(Camera.main.transform.forward * movementSpeed * Time.deltaTime);
        
        //output to log the position change
        //Debug.Log(transform.position);
    }
}
