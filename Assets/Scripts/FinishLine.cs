//we really don't use these namespaces so we can comment them out
//they are by default placed here
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
  [SerializeField] float SceneDelay = 2f;
  [SerializeField] ParticleSystem finishEffect;
  void OnTriggerEnter2D(Collider2D other) 
  {
      if(other.tag == "Player") 
      {
          finishEffect.Play();
          GetComponent<AudioSource>().Play();
          Invoke("ReloadScene", SceneDelay);
          
      }
      
  }

  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }

}
