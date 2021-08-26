using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
 public int hitValue = 1;

   private void OnCollisionEnter2D(Collision2D other) { 
           if (other.gameObject.CompareTag("Player")){
         HeartManager.instance.RemoveHeart(hitValue);
     }
   }
}
