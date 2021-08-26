using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this scripts handles the players collisions.
public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D _ridgidbody;//reference to physics.
    public float HitForce = 1;//how much character flies when hitting enemy


    private void Start() {
        _ridgidbody = GetComponent<Rigidbody2D>();
    }

  //function that runs everytime the character stops colliding with a trigger.
        public void OnTriggerExit2D(Collider2D other) { 
            //ends game if player is outside bounds.
            if (other.gameObject.CompareTag("Bounds")){
            FindObjectOfType<GameManager>().EndGame();
            }
        }
    //function that runs everytime the character collides with a trigger.
        public void OnTriggerEnter2D(Collider2D other) { 
            //collecting fishes
            if (other.gameObject.CompareTag("Fishes")){
                Destroy(other.gameObject);
            }
            //collecting hearts
            if (other.gameObject.CompareTag("Heart")){
                Destroy(other.gameObject);
            }

        }

}
