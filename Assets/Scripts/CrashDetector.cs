//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    //variable that is used to set the amount of delay between crash and game restart
    [SerializeField] float CrashSceneDelay = 2f;

    //sets variable of ParticleSystem type that we call "CrashEffect", the developer
    //has to drag and drop the particle system to set this variable to from the inspector
    [SerializeField] ParticleSystem CrashEffect;

    //variable of AudioClip type that is set to an audioclip file that we upload to unity
    //the developer has to drag and drop the file to this variable to from the inspector
    [SerializeField] AudioClip crashSFX;
    
    //boolean variable that is set to false at start of game. This variable will change when
    //the circle 
    bool hasCrashed = false;

    //When "Karen"'s object component that has the "is trigger" box checked off (circle collider)
    // enters/hits the object (other) with tag "Ground" and if the player hasn't crashed yet
    //(hasCrashed is false) then the player will:
    // Change hasCrashed to true to inform of crash
    // CrashEffect, particle system, will play
    // user will no longer be able to move the player (calls the Disable Controls method by
    //accessing the object of type (or script/class) Player controller ) as this method changes the
    //variable canMove to false
    //Get the component of AudioSource type on this object ("Karen") and uses the play method
    //to play specified sound
    //after creating a scene in the scenes folder and calling it Level1 (all objects, methods
    //and everything is placed into this scene when we create it), and making note of the number
    //assigned to the level in the inspector, the Inovke method calls the
    //"ReloadScene" method in this class, and sets the time between crash and reload
   void OnTriggerEnter2D(Collider2D other) 
  {
      if(other.tag == "Ground" && !hasCrashed) 
      {
          hasCrashed = true;
          FindObjectOfType<PlayerController>().DisableControls();
          CrashEffect.Play();
          GetComponent<AudioSource>().PlayOneShot(crashSFX);
          Invoke("ReloadScene", CrashSceneDelay);
      }
      
  }

//this method uses SceneManager to load scene the inital scene settings (essentially restarts)
//the game
  void ReloadScene () 
  {
      SceneManager.LoadScene(0);
  }

}
