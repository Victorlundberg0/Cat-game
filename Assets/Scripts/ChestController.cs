using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{

    //animator handler
    public Animator animator;
    private int chestValue = 1;
    private bool alreadyOpened;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isOpen",false);//make sure the chest is closed at start.
        alreadyOpened = false;
    }

     //function that runs everytime the character collides with a trigger.
    public void OnTriggerEnter2D(Collider2D other) { 
    //checks if quicksand
         if (other.gameObject.CompareTag("Player") && !alreadyOpened){
                animator.SetBool("isOpen",true);//opens chest when entering it.
                ChestManager.instance.AddChest(chestValue);
                alreadyOpened = true;
           }
      }


}
