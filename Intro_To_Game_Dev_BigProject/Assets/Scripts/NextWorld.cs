﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWorld : MonoBehaviour {
    public GameObject myObject;
    public GameObject otherObject;
    public GameObject theObject;
    public GameObject myObject2;
    public GameObject otherObject2;
    public GameObject theObject2;
    public GameObject myObject3;
    public GameObject otherObject3;
    public GameObject theObject3;
    public Text worldTime1;

	// Use this for initialization
	void Start () {
        
        unlockNextWorld();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void unlockNextWorld()
    {if (PlayerPrefs.HasKey("newTime" + 1) && PlayerPrefs.HasKey("newTime" + 2) && PlayerPrefs.HasKey("newTime" + 3) &&
        PlayerPrefs.HasKey("newTime" + 4) && PlayerPrefs.HasKey("newTime" + 5))
        {
           theObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
//        if (GameObject.FindGameObjectWithTag("LevelSelect").GetComponent<LevelSelect>().LevelComplete)
//        {
//            Destroy(myObject);
//        }
        if (PlayerPrefs.HasKey("newTime" + 1) && PlayerPrefs.HasKey("newTime" + 2) && PlayerPrefs.HasKey("newTime" + 3) &&
            PlayerPrefs.HasKey("newTime" + 4) && PlayerPrefs.HasKey("newTime" + 5) && PlayerPrefs.HasKey("newTime" + 6) &&
            PlayerPrefs.HasKey("newTime" + 7) && PlayerPrefs.HasKey("newTime" + 8) && PlayerPrefs.HasKey("newTime" + 9) &&
            PlayerPrefs.HasKey("newTime" + 10))
        {
            otherObject.GetComponent<Renderer>().material.color = Color.cyan;
            Destroy(myObject);
        }
        //2nd world
        if (PlayerPrefs.HasKey("newTime" + 11) && PlayerPrefs.HasKey("newTime" + 12) && PlayerPrefs.HasKey("newTime" + 13) &&
            PlayerPrefs.HasKey("newTime" + 14) && PlayerPrefs.HasKey("newTime" + 15))
        {
            theObject2.GetComponent<Renderer>().material.color = Color.cyan;
        }

        if (PlayerPrefs.HasKey("newTime" + 11) && PlayerPrefs.HasKey("newTime" + 12) && PlayerPrefs.HasKey("newTime" + 13) &&
            PlayerPrefs.HasKey("newTime" + 14) && PlayerPrefs.HasKey("newTime" + 15) && PlayerPrefs.HasKey("newTime" + 16) &&
            PlayerPrefs.HasKey("newTime" + 17) && PlayerPrefs.HasKey("newTime" + 18) && PlayerPrefs.HasKey("newTime" + 19) &&
            PlayerPrefs.HasKey("newTime" + 20))
        {
            otherObject2.GetComponent<Renderer>().material.color = Color.cyan;
            Destroy(myObject2);
        }
        //2nd world
        if (PlayerPrefs.HasKey("newTime" + 21) && PlayerPrefs.HasKey("newTime" + 22) && PlayerPrefs.HasKey("newTime" + 23) &&
            PlayerPrefs.HasKey("newTime" + 24) && PlayerPrefs.HasKey("newTime" + 25))
        {
            theObject3.GetComponent<Renderer>().material.color = Color.cyan;
        }

        if (PlayerPrefs.HasKey("newTime" + 21) && PlayerPrefs.HasKey("newTime" + 22) && PlayerPrefs.HasKey("newTime" + 23) &&
            PlayerPrefs.HasKey("newTime" + 24) && PlayerPrefs.HasKey("newTime" + 25) && PlayerPrefs.HasKey("newTime" + 26) &&
            PlayerPrefs.HasKey("newTime" + 27) && PlayerPrefs.HasKey("newTime" + 28) && PlayerPrefs.HasKey("newTime" + 29))
        {
            otherObject3.GetComponent<Renderer>().material.color = Color.cyan;
            Destroy(myObject3);
        }
        worldTime1.text = (PlayerPrefs.GetFloat("bestTime" + 1) + PlayerPrefs.GetFloat("bestTime" + 2) +PlayerPrefs.GetFloat("bestTime" + 3)
            + PlayerPrefs.GetFloat("bestTime" + 4) + PlayerPrefs.GetFloat("bestTime" + 5) + PlayerPrefs.GetFloat("bestTime" + 6)
            + PlayerPrefs.GetFloat("bestTime" + 7) + PlayerPrefs.GetFloat("bestTime" + 8) + PlayerPrefs.GetFloat("bestTime" + 9)
            + PlayerPrefs.GetFloat("bestTime" + 10).ToString());
    }
    void ChangeColorToBlack()
    {
        otherObject.GetComponent<Renderer>().material.color = Color.black;
    }

}
