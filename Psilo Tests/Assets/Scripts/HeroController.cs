using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerInput))]
public class HeroController : MonoBehaviour {

    //This script does not get input straight from Unity, but rather from a PlayerInput script.  

    public float runningSpeed = 1f;
    public float turnSpeed = 1f;
    float forwardmove = 0f;
    float lateralmove = 0f;
    Animator anim;
    PlayerInput playerInput;

    void Start() {
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        turnSpeed = 100f;
    }

    	
	
	void Update ()
    {
        GetInputs();
        UpdateAnimations();
        MoveHero();
    }


    void GetInputs()
    {
        forwardmove = playerInput.GetVerticalInput();
        lateralmove = playerInput.GetHorizontalInput();
    }

    void MoveHero()
    {
        
        if (forwardmove > 0.7)   // <-- initially, the movement started before feet moved.  This value compensates. 
        {
            transform.Translate(Vector3.forward * runningSpeed * Time.deltaTime);
        }

        if (lateralmove > 0.3)   
        {
            transform.Rotate(0f, lateralmove * turnSpeed * Time.deltaTime, 0f);
        }

        if (lateralmove < -0.3)  
        {
            transform.Rotate(0f, lateralmove * turnSpeed * Time.deltaTime, 0f);
        }
    }

    void UpdateAnimations()
    {
        anim.SetFloat("Running",forwardmove);
    }

}
