//we really don't use these namespaces so we can comment them out
//they are by default placed here
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
  // float variable that sets the delay between finishing the game and restarting game, is changed
  // on the inspector
  [SerializeField] float SceneDelay = 2f;
  //variable of type ParticleSystem, this variable is set in the inspector by dragging the particle
  //system object ("Finish Effect" in this case) into the variable field
  [SerializeField] ParticleSystem finishEffect;

  //When the component on this object ("Finish Line") with the "is Trigger" box checked off (box collider
  //in this case) entered by the object called "player" this method will:
  //play the finish particle effects
  //Get the AudioSource Component on this object ("Finish Line") and play the sound file
  //and will then use the Invoke function to execute the "ReloadScene" method in this class to
  //restart game. the time between restart and finish is set by the SceneDelay variable
  void OnTriggerEnter2D(Collider2D other) 
  {
      if(other.tag == "Player") 
      {
          finishEffect.Play();
          GetComponent<AudioSource>().Play();
          Invoke("ReloadScene", SceneDelay);
          
      }
      
  }

//this method uses SceneManager to load scene the inital scene settings (essentially restarts)
//the game
  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }

}
