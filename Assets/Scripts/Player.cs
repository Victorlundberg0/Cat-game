using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables

    public float movementSpeed = 1;
    public float JumpForce = 13;
    public float bounceForce = 20;
    public float swimForce = 3;
    private Rigidbody2D _ridgidbody;
    public bool isOnGround; // whether the character is on ground or not.
    public bool hasLost; // whether the character is on ground or not.
    private bool isInWater;
    public Collider2D bodyCollider;//reference to the capsule collider.
    public LayerMask groundLayer;//reference to the layer where the ground is on.
    public LayerMask WaterLayer;//reference to the layer where the ground is on.

    //animator handler
    public Animator animator;

    private void Start() {
        _ridgidbody = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //left and right movement
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * movementSpeed;
        //flip the character to left or right.
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0) {
            characterScale.x = -0.05f;
        }
         if (Input.GetAxis("Horizontal") > 0) {
            characterScale.x = 0.05f;
        }
        transform.localScale = characterScale;
        //Jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_ridgidbody.velocity.y) < 0.001f && !hasLost && !isInWater) {
            _ridgidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            isOnGround = false;
            animator.SetBool("isJumping",true);//changes animation
        }
        //swim
            if (Input.GetButtonDown("Jump") && isInWater) {
            _ridgidbody.AddForce(new Vector2(0, swimForce), ForceMode2D.Impulse);
        }
    
        //As soon as the character is moving the animation changes to the run animation.
        animator.SetFloat("speed", Mathf.Abs(movement));
        //
        if (isOnGround) {
            animator.SetBool("isJumping",false);
        }

            if (bodyCollider.IsTouchingLayers(WaterLayer)) {
                    isOnGround = true;
                isInWater = true;
                _ridgidbody.gravityScale = 0.1f;
            }
        
    }

//collisions

        //function that runs everytime the character collides with a trigger.
        public void OnTriggerEnter2D(Collider2D other) { 
        //checks if quicksand
            if (other.gameObject.CompareTag("Sand")){
                 isOnGround = true;
                 hasLost = true;
                 _ridgidbody.gravityScale = 0.1f;
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
                  if (other.gameObject.CompareTag("water")){
                    isOnGround = false;
                    isInWater = false;
                    _ridgidbody.gravityScale = 3f;
            } 
        }
      

        //function that runs everytime the character collide with a object.
        public void OnCollisionEnter2D(Collision2D other) { 
            //checks if on ground
            if (bodyCollider.IsTouchingLayers(groundLayer)) {
                isOnGround = true;
            }
            if (other.gameObject.CompareTag("sandTrigger")){
                Destroy(other.gameObject);
            }
              if (other.gameObject.CompareTag("trampoline") && Mathf.Abs(_ridgidbody.velocity.y) < 0.001f){
                _ridgidbody.AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);
                isOnGround = false;
                animator.SetBool("isJumping",true);//changes animation
            }
        
        }
        //function that runs everytime the character stops colling with a object.
        public void OnCollisionExit2D(Collision2D other) { 
            //check if in air
             if (other.gameObject.CompareTag("Ground")){
                 isOnGround = false;
            }
        }
}
