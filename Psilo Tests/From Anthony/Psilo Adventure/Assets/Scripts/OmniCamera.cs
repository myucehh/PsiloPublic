using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerInput))]
public class OmniCamera : MonoBehaviour {

    // Camera script is to be attached to the Main Camera.  
    // A PlayerInput script is required for controlling rotation and such.  
    
        // Initial camera placement is determined in the Inspector.
    // This script governs how the camera moves and rotates once play has begin, based on where it was initially placed. 


    public enum CameraType { Static, Follow, RotateAround, FirstPerson, SelfieMode };   //sets the options available for list of camera types
    public CameraType cameraType;   //sets up a variable to be set in the Inspector, using options for camera types
    string cameraoption;            //sets up a string to hold the camera type selected in the inspector
    Transform target;
    Vector3 cameraToPlayerVector;
    Vector3 rotationVector;
    public float cameraSpeed = 1;   //for smoothest results, the camera flies through space at its own speed
    PlayerInput playerInput;
    public float cameraFocus = 2f;  // how high above the characters head is the camera aimed? 

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        cameraoption = cameraType.ToString();       //converts camera type to a string, making it easier for me to work with
        cameraToPlayerVector = transform.position - target.position;
        rotationVector = cameraToPlayerVector;
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        cameraoption = cameraType.ToString();       //command repeats in update so camera type can be changed during playtesting
    }

    
    

    void LateUpdate()
    {

        if (cameraoption == "SelfieMode")
        {
            float rotateMotion = playerInput.GetMouseHorizontalInput() * cameraSpeed;
            target.transform.Rotate(0, rotateMotion, 0); 
            float desiredAngle = target.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = target.transform.position - (rotation * cameraToPlayerVector);
        }

        if (cameraoption == "Follow")
        {
            if (playerInput.GetMouseMoveStatus() == true)
                { target.transform.Rotate(0, (playerInput.GetMouseHorizontalInput() * cameraSpeed), 0); }
            float desiredAngle = target.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = target.transform.position + (rotation * cameraToPlayerVector);
        }
   


        if (cameraoption == "RotateAround")
        {
            rotationVector = Quaternion.AngleAxis(playerInput.GetMouseHorizontalInput() * cameraSpeed, Vector3.up) * rotationVector;
            transform.position = target.position + rotationVector;

        }
        if (cameraoption == "FirstPerson")
        {
            if (playerInput.GetMouseMoveStatus() == true)
            { target.transform.Rotate(0, (playerInput.GetMouseHorizontalInput() * cameraSpeed), 0); }
            transform.position = new Vector3(target.position.x, target.position.y + 1.5f, target.position.z + 0.6f);
            float desiredAngle = target.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = target.transform.position + (rotation * (transform.position-target.position));
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, target.eulerAngles.y, transform.eulerAngles.z);
        }
        else transform.LookAt(new Vector3(target.position.x, target.position.y+cameraFocus, target.position.z));


        
        
        

    }


    
}
