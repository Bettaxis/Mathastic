using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour {

    public GameObject block;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	if (Input.GetKeyDown(KeyCode.Space)) // Spawns on Spacebar
        {
           GameObject copy;
            copy = Instantiate(block, transform.position, transform.rotation);
            copy.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.down);
        }
	}
}
