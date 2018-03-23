using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{

    public GameObject block;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Spawns on 1
        {
            GameObject copy;
            copy = Instantiate(block, new Vector3(1, transform.position.y, 5), transform.rotation);
            copy.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // Spawns on 2
        {
            GameObject copy;
            copy = Instantiate(block, new Vector3(1, transform.position.y, -5), transform.rotation);
            copy.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.down);
        }
    }

}
