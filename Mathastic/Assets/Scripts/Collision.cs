using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    Rigidbody RB;
    public float UnitMass;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}




    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided!");

        if (collision.CompareTag("Division"))
        {
            RB = this.GetComponent<Rigidbody>();
            RB.mass = (RB.mass / 2);
        }

        if (collision.CompareTag("Multiply"))
        {
            RB = this.GetComponent<Rigidbody>();
            RB.mass = (RB.mass * 2);
        }

        if (collision.CompareTag("Add"))
        {
            RB = this.GetComponent<Rigidbody>();
            RB.mass = (RB.mass + UnitMass);
        }   

        if (collision.CompareTag("Minus"))
        {
            RB = this.GetComponent<Rigidbody>();
            RB.mass = (RB.mass - UnitMass);
        }

    }
}
