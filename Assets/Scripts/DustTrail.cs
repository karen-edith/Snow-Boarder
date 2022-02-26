using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
  //decalres variable dustTrail as a variable of type ParticleSystem, the developer will have to
  //initialize/set the variable in the inspector by dragging the needed particle system to this
  //variable 
  [SerializeField] ParticleSystem dustTrail;

  //when "Karen" collides and is in contact with the object that is tagged as "Ground"
  //play particle system effects
   void OnCollisionEnter2D(Collision2D other) 
   {
       
       if (other.gameObject.tag == "Ground")
       {
            dustTrail.Play();
       }
       
   }

   //When "Karen" is no longer in conact with the object tagged as "Ground" stop particle system
   // dustTrail effects

   void OnCollisionExit2D(Collision2D other) 
   {
        if (other.gameObject.tag == "Ground")
       {
           dustTrail.Stop();
       }   
   }


}
