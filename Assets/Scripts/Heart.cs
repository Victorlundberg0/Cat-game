using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
 public int hitValue = 1;

   private void OnTriggerEnter2D(Collider2D other) { 
    if (other.gameObject.CompareTag("Player")){
         HeartManager.instance.AddHeart(hitValue);
     }
   }
}
