using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    public Text textObject;
    public Text warning;

    float timer = 100.0f;
    float triggerTime = 0.0f;
    bool imbalanced = false;
    bool lost = false;
	// Use this for initialization
	void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        triggerTime -= Time.deltaTime;
    }

    void LateUpdate()
    {
        if (triggerTime < 0 && imbalanced) //you lose
        {
            Destroy(FindObjectOfType<SpawnCube>());
            lost = true;
        }

        //textObject.text = timer.ToString();
        if (!lost)
            warning.text = imbalanced ? ((int)triggerTime).ToString() : "";
        else
            warning.text = "You Lost!\nPress Space\n to restart.";

        if ((lost && Input.GetKeyDown(KeyCode.Space)) || (lost && Input.GetKeyDown(KeyCode.DownArrow)))
            UnityEngine.SceneManagement.SceneManager.LoadScene("BaseLevel");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Tray"))
            return;
        triggerTime = 10.0f;
        imbalanced = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Tray"))
            return;
        triggerTime = 0.0f;
        imbalanced = false;
    }


}
