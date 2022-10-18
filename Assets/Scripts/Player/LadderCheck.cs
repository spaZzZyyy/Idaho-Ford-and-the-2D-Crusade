using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderCheck : MonoBehaviour
{
   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Ladder"))
      {
         PlayerMovement.Instance.velocityY = 0;
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      PlayerMovement.Instance.velocityY = -1;
   }
}
