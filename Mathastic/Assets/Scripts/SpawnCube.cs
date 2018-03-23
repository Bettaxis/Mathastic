using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{

    public GameObject block;

    public Transform leftTray;
    public Transform rightTray;
    public float blockSpawnVertOffset = 10;
    public float trayWidth = 0.5f;

    private GameObject fallingBlock;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1)) // Spawns on 1
        //{
        //    GameObject copy;
        //    copy = Instantiate(block, new Vector3(1, transform.position.y, 5), transform.rotation);
        //    copy.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.down);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2)) // Spawns on 2
        //{
        //    GameObject copy;
        //    copy = Instantiate(block, new Vector3(1, transform.position.y, -5), transform.rotation);
        //    copy.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.down);
        //}

        if (!fallingBlock)
        {
            float val = Random.Range(0.0f, 1.0f);
            if (val > 0.5)
            {
                fallingBlock = Instantiate(block, rightTray);
                fallingBlock.transform.localScale = new Vector3(1.0f / 5.0f, 1.0f / 0.25f, 1.0f / 5.0f);
                fallingBlock.transform.localPosition = new Vector3(0, blockSpawnVertOffset, 0);
            }
            else
            {
                fallingBlock  = Instantiate(block, leftTray);
                fallingBlock.transform.localScale = new Vector3(1.0f / 5.0f, 1.0f / 0.25f, 1.0f / 5.0f);
                fallingBlock.transform.localPosition = new Vector3(0, blockSpawnVertOffset, 0);
            }
        }

        //fallingBlock.transform.localPosition = new Vector3(fallingBlock.transform.localPosition.x, 10, fallingBlock.transform.localPosition.z);
        //fallingBlock.transform.localScale = new Vector3(1 / fallingBlock.transform.parent.localScale.x, 1 / fallingBlock.transform.parent.localScale.y, 1 / fallingBlock.transform.parent.localScale.z);

        print(fallingBlock.transform.localPosition.z + " : " + trayWidth / 10);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (fallingBlock.transform.localPosition.z > trayWidth / 10)
            {
                print("right");
                //right edge of tray
                if (fallingBlock.transform.parent = leftTray)
                {
                    Vector3 pos = new Vector3(fallingBlock.transform.localPosition.x, fallingBlock.transform.localPosition.y, 0);
                    fallingBlock.transform.parent = rightTray;
                    fallingBlock.transform.localPosition = pos;
                }
            }
            else
                fallingBlock.transform.localPosition += new Vector3(0, 0, -0.15f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (fallingBlock.transform.localPosition.z < -trayWidth / 10)
            {
                print("left");
                //left edge of tray
                if (fallingBlock.transform.parent = rightTray)
                {
                    Vector3 pos = new Vector3(fallingBlock.transform.localPosition.x, fallingBlock.transform.localPosition.y, 0);
                    fallingBlock.transform.parent = leftTray;
                    fallingBlock.transform.localPosition = pos;
                }
            }
            else
                fallingBlock.transform.localPosition += new Vector3(0, 0, 0.15f);
        }


    }

}
