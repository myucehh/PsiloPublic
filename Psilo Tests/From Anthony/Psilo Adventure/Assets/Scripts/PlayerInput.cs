using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    // This script gets information about the current user input with the mouse and keyboard.  It makes this information
    // available for other scripts to get during its update process.  This allows you to easily change key configurations, 
    // configure different controller types, add local multiplayer options, and otherwise change or simulate player input
    // easily without modifying other scripts. 
    // This script should go on every object that the player has control over, such as the player character and camera. 


    float inputVertical;
    float inputHorizontal;
    float inputMouseHorizontal;
    float inputMouseVertical;
    string inputAction;
    bool mousemove;
	
	void Update ()
    {
        ResetInputValues();
        inputVertical = Input.GetAxis("Vertical");
        if (Input.GetMouseButton(2)) { mousemove = true;  inputVertical = 1.0f; } else { mousemove = false; }
        inputHorizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) { inputAction = "Jump"; }
        if (Input.GetMouseButtonDown(0)) { inputAction = "Jump"; }
        if (Input.GetKeyDown(KeyCode.Return)) { inputAction = "Toss"; }
        if (Input.GetMouseButtonDown(1)) { inputAction = "Toss"; }
        inputMouseHorizontal = Input.GetAxis("Mouse X");
        inputMouseVertical = Input.GetAxis("Mouse Y");
    }

    void ResetInputValues()
    {
        //Shared variables for buttons presses need to have values reset. Floats from Horizontal and Vertical "GetAxis" don't. 
        inputAction = "";
    }

    public float GetVerticalInput()
    { return inputVertical; }

    public float GetHorizontalInput()
    { return inputHorizontal; }

    public float GetMouseVerticalInput()
    { return inputMouseVertical; }

    public float GetMouseHorizontalInput()
    { return inputMouseHorizontal; }

    public string GetActionInput()
    { return inputAction; }

    public bool GetMouseMoveStatus()
    { return mousemove; }



}
