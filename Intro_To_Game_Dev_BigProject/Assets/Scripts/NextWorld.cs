using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWorld : MonoBehaviour {
    public GameObject myObject;
    public GameObject otherObject;
    public GameObject theObject;
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


    }
    void ChangeColorToBlack()
    {
        otherObject.GetComponent<Renderer>().material.color = Color.black;
    }

}
