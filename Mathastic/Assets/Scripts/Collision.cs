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

    public Color[] colours = { Color.red, Color.blue, Color.green,
                               Color.yellow, Color.cyan, Color.magenta,
                               new Color(1.0f, 0.5f, 0.02f), new Color(1.0f, 0.0f, 1.0f), new Color(0.0f, 0.0f, 0.0f)};

    // Use this for initialization
    void Start () {
        RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetBlock(Tag type, float value)
    {
        if (value <= 0)
            value = 1;
        tag = type.ToString();
        if (!RB)
            RB = GetComponent<Rigidbody>();
        RB.mass = value;
        text.text = "" + RB.mass;

        switch (type)
        {
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

        GetComponent<Renderer>().material.color = colours[((int)value - 1) % 10];
    }


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        //print(name + " Collided with: " + collision.transform.gameObject.name);
        if(!spent)
        if (collision.transform.gameObject.tag.Equals("Division"))
        {
            SetBlock(Tag.Mass, (collision.gameObject.GetComponent<Rigidbody>().mass / RB.mass));
            collision.gameObject.GetComponent<Collision>().spent = true;
            GameObject.Destroy(collision.gameObject);
        }

        else if (collision.transform.gameObject.tag.Equals("Multiply"))
        {
            SetBlock(Tag.Mass, (collision.gameObject.GetComponent<Rigidbody>().mass * RB.mass));
            collision.gameObject.GetComponent<Collision>().spent = true;
            GameObject.Destroy(collision.gameObject);
        }

        else if (collision.transform.gameObject.tag.Equals("Add") && !tag.Equals("Multiply"))
        {
            SetBlock(Tag.Mass, (collision.gameObject.GetComponent<Rigidbody>().mass + RB.mass));
            collision.gameObject.GetComponent<Collision>().spent = true;
            GameObject.Destroy(collision.gameObject);
        }   

        else if (collision.transform.gameObject.tag.Equals("Minus") && !tag.Equals("Multiply"))
        {
            SetBlock(Tag.Mass, (collision.gameObject.GetComponent<Rigidbody>().mass - RB.mass));
            collision.gameObject.GetComponent<Collision>().spent = true;
            GameObject.Destroy(collision.gameObject);
        }

    }
    
}
