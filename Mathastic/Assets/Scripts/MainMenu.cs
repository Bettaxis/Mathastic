using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject Menu;
    public GameObject How;
    public GameObject Bs;
    public GameObject Hs;
    public GameObject Qs;
    public int selection = 1;
    bool how = false;

    // Use this for initialization
    void Start () {
        Menu = GameObject.Find("mainmenu");
        Bs = GameObject.Find("beginselect");
        Hs = GameObject.Find("howselect");
        Qs = GameObject.Find("quitselect");
        How = GameObject.Find("how");
    }
	
	// Update is called once per frame
	void Update () {
        if (!how)
        {
            How.SetActive(false);
            Menu.SetActive(true);
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selection += 1;
                if (selection > 3)
                    selection = 1;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selection -= 1;
                if (selection < 1)
                    selection = 3;
            }

            if (selection == 1)
                Bs.SetActive(true);
            else
                Bs.SetActive(false);
            if (selection == 2)
                Hs.SetActive(true);
            else
                Hs.SetActive(false);
            if (selection == 3)
                Qs.SetActive(true);
            else
                Qs.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                if (selection == 1)
                    Application.LoadLevel("BaseLevel");
                else if (selection == 2)
                    how = true;
                else if (selection == 3)
                    Application.Quit();
            }
        }
        else
        {
            How.SetActive(true);
            Menu.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Escape))
                how = false;
        }
    }
}
