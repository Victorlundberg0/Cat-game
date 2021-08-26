using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRock : MonoBehaviour
{

  private Vector2 originalPos; //variable to save original position of the rock.
  private Rigidbody2D _ridgidbody;

    void Start()
    {
      _ridgidbody = GetComponent<Rigidbody2D>();
        //saves the original posotion of the rock.
        originalPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }


      //function that runs everytime the character stops colliding with a trigger.
        public void OnTriggerExit2D(Collider2D other) { 
            //reloads rock to original position if out of bounds.
            if (other.gameObject.CompareTag("Bounds")){
              gameObject.transform.position = originalPos;
            }
        }
 
        private void OnCollisionStay2D(Collision2D other) {
          //removes from trampoline.
            if (other.gameObject.CompareTag("trampoline")){
              _ridgidbody.AddForce(new Vector2(-1, 1), ForceMode2D.Impulse);
            }
            
        }
}
