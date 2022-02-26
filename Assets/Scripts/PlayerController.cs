using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //parameter for the amount of rotation
    [SerializeField] float torqueAmount = 1f;
    //Parameter to increase speed for snowboarder 
    [SerializeField] float boostspeed = 40f;
    //parameter for start speed of snowboarder
    [SerializeField] float baseSpeed = 20f;
    //variable of type Rigidbody2D that we'll use to apply torque to player based on
    //user key input
    Rigidbody2D rb2d;
    
    //varibale of type surfaceEffector2D that we'll use to speed up the convyer belt
    //(shape collider) thats applied to the mountain
    SurfaceEffector2D surfaceEffector2D;
    
    //boolean variable that will prevent the user from moving the player once
    //they've crashed, by default it's set to true because when we start the game
    //we haven't crashed yet
    bool canMove = true;
    void Start()
    {
       //when game starts, initiate rb2d variable with the RigidBody2D component "Karen"
       //object
       rb2d = GetComponent<Rigidbody2D>();
       //when game starts, initiate surfaceEffector2D variable with the SurfaceEffector2D
       //component on the object that has that component (in this case this is the object
       //"Level Sprite Shape")
       surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //on every frame/scene update this block of code checks to see if the player
        // has crashed (if canMove is true), if the player has not crashed then the user
        //will be able to use their keys to move the player and to boost their player
        //otherwise they loose the control
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }

    }

    // if player crashes, this method is called from crash detector to change its value
    //from true to false, once this variable is set to false, the player will no longer
    // be able to move
    public void DisableControls() 
    {
    
        canMove = false;
    }

    void RespondToBoost()
    {
        // if we push up, then speed up arrow the player will speed up because we're
        // icreasing the speed of the converybelt, but this boost is only applied when the 
        // player is in contact with the mountain surface, otherwise if they're in the 
        // air it won't apply adnd the speed return to the base speed
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            surfaceEffector2D.speed = boostspeed;
        }
        else 
        {
            surfaceEffector2D.speed = baseSpeed;
        }
        

    }

    void RotatePlayer()
    {
        //if the user hits the left arrow, rotate the player by torqueAmount in the 
        //backwrds direction
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }

        //if the user hits the right arrow, rotate the player by torqueAmount in the
        //forwards (opposite to backwards) direction

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-1 * torqueAmount);
        }
    }
}
