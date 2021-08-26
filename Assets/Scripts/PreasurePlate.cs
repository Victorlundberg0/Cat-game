using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlate : MonoBehaviour
{
    private float totalPreasure;
    public HingeJoint2D _removeHinge;
    public HingeJoint2D Hinge1;
    public HingeJoint2D Hinge2;
    public HingeJoint2D Hinge3;
    public HingeJoint2D Hinge4;
    // Start is called before the first frame update
    void Start()
    {
        //make sure the plate has no preasure at start.
        totalPreasure = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
            Rigidbody2D _rigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            totalPreasure += _rigidbody.mass; 
          if(totalPreasure > 5.9) {
            Destroy(_removeHinge, 2);
            Destroy(Hinge1, 3);
            Destroy(Hinge2, 3);
            //Destroy(Hinge3, 4);
            //Destroy(Hinge4, 4);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        Rigidbody2D _rigidbody = other.gameObject.GetComponent<Rigidbody2D>();
        totalPreasure -= _rigidbody.mass;
    }

}
