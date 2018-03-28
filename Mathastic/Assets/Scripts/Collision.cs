using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    Rigidbody RB;
    public float UnitMass = 0.0f;
    public Text text;
    bool spent;
    

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
        if(!spent)
        if (collision.transform.gameObject.tag.Equals("Division"))
        {
            RB.mass = (collision.gameObject.GetComponent<Rigidbody>().mass / RB.mass);
            print(name + " New mass of " + RB.mass);
            collision.gameObject.GetComponent<Collision>().spent = true;
            GameObject.Destroy(collision.gameObject);
            UpdateText();
        }

        else if (collision.transform.gameObject.tag.Equals("Multiply"))
        {
            RB.mass = (collision.gameObject.GetComponent<Rigidbody>().mass * RB.mass);
            print(name + " New mass of " + RB.mass);
            collision.gameObject.GetComponent<Collision>().spent = true;
            GameObject.Destroy(collision.gameObject);
            UpdateText();
        }

        else if (collision.transform.gameObject.tag.Equals("Add") && !tag.Equals("Multiply"))
        {
            RB.mass = (collision.gameObject.GetComponent<Rigidbody>().mass + RB.mass);
            print(name + " New mass of " + RB.mass);
            collision.gameObject.GetComponent<Collision>().spent = true;
            GameObject.Destroy(collision.gameObject);
            UpdateText();
        }   

        else if (collision.transform.gameObject.tag.Equals("Minus") && !tag.Equals("Multiply"))
        {
            RB.mass = (collision.gameObject.GetComponent<Rigidbody>().mass - RB.mass);
            print(name + " New mass of " + RB.mass);
            collision.gameObject.GetComponent<Collision>().spent = true;
            GameObject.Destroy(collision.gameObject);
            UpdateText();
        }

    }

    private void UpdateText(){
        
        text.text = "" + RB.mass;
        switch((Tag)System.Enum.Parse(typeof(Tag), tag)){
            case Tag.Add:
            text.text += "+";
            break;
            case Tag.Division:
            text.text += "÷";
            break;
            case Tag.Minus:
            text.text += "-";
            break;
            case Tag.Multiply:
            text.text += "X";
            break;
        }
    }

    
}
