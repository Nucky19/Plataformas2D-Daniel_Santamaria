using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundsensor : MonoBehaviour
{
   public static bool isGrounded;

   void OnTriggerEnter2D(Collider2D collider){
     if(collider.gameObject.layer == 6){
        isGrounded = true;
        playermovement.anim.SetBool("IsJumping",false);
     }
    
   }

   void OnTriggerStay2D(Collider2D collider){
    if(collider.gameObject.layer == 6) isGrounded = true;
   }

   void OnTriggerExit2D(Collider2D collider){
    if(collider.gameObject.layer == 6){
        isGrounded = false;
        playermovement.anim.SetBool("IsJumping",true);
    }
    
   }
}
