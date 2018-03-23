using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    public Text textObject;

    float timer = 100.0f;

	// Use this for initialization
	void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
    }

    void LateUpdate()
    {
        textObject.text = timer.ToString();
    }
}
