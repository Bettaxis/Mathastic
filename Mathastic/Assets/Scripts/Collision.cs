using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    Rigidbody RB;
    public float UnitMass = 0.0f;
    

	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}




    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        print(name + " Collided with: " + collision.transform.gameObject.name);

        if (collision.transform.gameObject.tag.Equals("Division"))
        {
            RB.mass = (RB.mass / 2);
            print(name + " New mass of " + RB.mass);
            GameObject.Destroy(collision.gameObject);
            tag = "Division";
        }

        else if (collision.transform.gameObject.tag.Equals("Multiply"))
        {
            RB.mass = (RB.mass * 2);
            print(name + " New mass of " + RB.mass);
            GameObject.Destroy(collision.gameObject);
            tag = "Multiply";
        }

        else if (collision.transform.gameObject.tag.Equals("Add"))
        {
            RB.mass = (RB.mass + UnitMass);
            print(name + " New mass of " + RB.mass);
            GameObject.Destroy(collision.gameObject);
            tag = "Add";
        }   

        else if (collision.transform.gameObject.tag.Equals("Minus"))
        {
            RB.mass = (RB.mass - UnitMass);
            print(name + " New mass of " + RB.mass);
            GameObject.Destroy(collision.gameObject);
            tag = "Minus";
        }

    }

    
}
