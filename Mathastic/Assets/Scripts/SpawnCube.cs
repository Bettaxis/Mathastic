using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{

    public GameObject block;

    public Transform leftTray;
    public Transform rightTray;
    public float blockSpawnVertOffset = 50.0f;
    public float trayWidth = 0.5f;
    public Color[] colours = { Color.red, Color.blue, Color.green, Color.yellow, Color.cyan, Color.magenta, new Color(1.0f, 0.5f, 0.02f), new Color(1.0f, 0.0f, 1.0f) };

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
            //MakeBlock();
        }else{
            fallingBlock.transform.localPosition = new Vector3(fallingBlock.transform.localPosition.x, blockSpawnVertOffset, fallingBlock.transform.localPosition.z);
            fallingBlock.GetComponent<Rigidbody>().velocity = new Vector3();
        }
        //fallingBlock.transform.localPosition = new Vector3(fallingBlock.transform.localPosition.x, 10, fallingBlock.transform.localPosition.z);
        //fallingBlock.transform.localScale = new Vector3(1 / fallingBlock.transform.parent.localScale.x, 1 / fallingBlock.transform.parent.localScale.y, 1 / fallingBlock.transform.parent.localScale.z);

        //print(fallingBlock.transform.localPosition.z + " : " + trayWidth / 10);

        if (Input.GetKeyDown(KeyCode.RightArrow) && fallingBlock)
        {
            if (fallingBlock.transform.localPosition.z <= -0.25f)
            {
                print("right");
                //right edge of tray
                if (fallingBlock.transform.parent == leftTray)
                {
                    Vector3 pos = new Vector3(fallingBlock.transform.localPosition.x, blockSpawnVertOffset, 0.4f);
                    fallingBlock.transform.SetParent(rightTray);
                    fallingBlock.transform.localPosition = pos;
                }
            }
            else
                fallingBlock.transform.localPosition += new Vector3(0, 0, -0.2f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && fallingBlock)
        {
            if (fallingBlock.transform.localPosition.z >= 0.25f)
            {
                print("left");
                //left edge of tray
                if (fallingBlock.transform.parent == rightTray)
                {
                    Vector3 pos = new Vector3(fallingBlock.transform.localPosition.x, blockSpawnVertOffset, -0.4f);
                    fallingBlock.transform.SetParent(leftTray);
                    fallingBlock.transform.localPosition = pos;
                }
            }
            else
                fallingBlock.transform.localPosition += new Vector3(0, 0, 0.2f);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            MakeBlock();
        }


    }

    private void MakeBlock(){
        if(fallingBlock)
        {
            fallingBlock.transform.localPosition = fallingBlock.transform.localPosition - new Vector3(0.0f, 5.0f, 0.0f);
        }
        int rng = Random.Range(0, 2);
        Transform parent = rightTray;
        if (rng == 1)
                  parent = leftTray;

        fallingBlock = Instantiate(block, parent);
        fallingBlock.transform.localScale = new Vector3(0.99f / 5.0f, 0.99f / 0.25f, 0.99f / 5.0f);
        fallingBlock.transform.localPosition = new Vector3(0, blockSpawnVertOffset, 0);
        

        // set the block's tag, mass, and text
        rng = Random.Range(0, 10);//(int)Tag.Mass);
        if(rng > (int)Tag.Mass)
            rng = (int)Tag.Mass;

        if(rng == (int)Tag.Division)
            rng++;

        fallingBlock.tag = ((Tag)rng).ToString();
          
        fallingBlock.GetComponent<Rigidbody>().mass = Random.Range(1, 10);

        if(rng == (int)Tag.Minus)
            fallingBlock.GetComponent<Rigidbody>().mass = Random.Range(1,3) * 5;
        if(rng == (int)Tag.Multiply)
            fallingBlock.GetComponent<Rigidbody>().mass = Random.Range(1,4) * 2;
        
        fallingBlock.GetComponent<Collision>().text.text = "" + fallingBlock.GetComponent<Rigidbody>().mass;
        switch((Tag)rng){
            case Tag.Add:
            fallingBlock.GetComponent<Collision>().text.text += "+";
            break;
            case Tag.Division:
            fallingBlock.GetComponent<Collision>().text.text += "÷";
            break;
            case Tag.Minus:
            fallingBlock.GetComponent<Collision>().text.text += "-";
            break;
            case Tag.Multiply:
            fallingBlock.GetComponent<Collision>().text.text += "X";
            break;
        }

        // set the colour
        rng = Random.Range(0, colours.Length);
        fallingBlock.GetComponent<Renderer>().material.color = colours[rng];
    }


}

public enum Tag{
    Add = 0,
    Minus = 1,
    Division,
    Multiply,
    Mass
};