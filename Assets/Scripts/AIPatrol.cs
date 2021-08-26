using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public bool mustPatrol;//whether the enemy is walking or not.
    private bool mustFlip;//whether the enemy should flip or not.
    public Rigidbody2D rb;//reference to physics object.
    public float WalkSpeed;//the speed the enemy walks.
    public Transform groundCheckPosition;//the position of the enemys child object.
    public LayerMask groundLayer;//reference to the layer where the ground is on.
    public Collider2D bodyCollider;//reference to the collider to tell whether it hit a wall.
    private Vector2 originalPos; //variable to save original position of the enemy.

    void Start()
    {
        mustPatrol = true;//enemy starts walking.
        //saves the original posotion of the enemy.
        originalPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    // Update is called once per frame
    void Update(){
        if(mustPatrol){
            Patrol();
        }
    }

    private void FixedUpdate() {
        if(mustPatrol) {
            //returns true if circle contains ground and false if not.
            mustFlip = !Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);
        }
    }

    //makes the enemy move.
    void Patrol() {
        //mustFlip || bodyCollider.IsTouchingLayers(groundLayer) 
    if (mustFlip || bodyCollider.IsTouchingLayers(groundLayer) ) {
            Flip();
        }
        rb.velocity = new Vector2(WalkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    //flips enemy when it reaches end of platform.
    void Flip() {
        mustPatrol = false;//enemy stops walking.
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);//flip.
        WalkSpeed *= -1;//flip.
        mustPatrol = true;//starts again after flip.
    }
    //function that runs everytime the character stops colliding with a trigger.
    public void OnTriggerExit2D(Collider2D other) { 
            //reloads enemy to original position if out of bounds.
            if (other.gameObject.CompareTag("Bounds")){
              gameObject.transform.position = originalPos;
            }
    }
    public void OnTriggerEnter2D(Collider2D other) { 
            //reloads enemy to original position if out of bounds.
            if (other.gameObject.CompareTag("Sand")){
              gameObject.transform.position = originalPos;
            }
    }
}
