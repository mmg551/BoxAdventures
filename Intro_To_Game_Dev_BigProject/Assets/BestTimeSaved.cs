using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BestTimeSaved : MonoBehaviour {
    public Text bestTime;
    public int levelNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void getTime()
    {
        if (PlayerPrefs.HasKey("bestTime" + levelNumber))
        {
            PlayerPrefs.GetFloat("bestTime" + levelNumber);
            bestTime.text = PlayerPrefs.GetFloat("bestTime" + levelNumber).ToString();
        }
        else
        {
            bestTime.text = "0000";
        }
    }
}
