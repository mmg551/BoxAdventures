using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BestTimeSaved : MonoBehaviour {
    public Text bestTime;
    public int levelNumber;
    float[] theBest = new float[30];
    float[] newTime = new float[30];

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("newTime" + levelNumber))
        {
            newTime[levelNumber] = PlayerPrefs.GetFloat("newTime" + levelNumber);

            if (newTime[levelNumber] > 0)
            {
                if (theBest[levelNumber] > 0)
                {
                    if (newTime[levelNumber] < theBest[levelNumber])
                    {
                        PlayerPrefs.SetFloat("bestTime" + levelNumber, newTime[levelNumber]);
                        bestTime.text = PlayerPrefs.GetFloat("bestTime" + levelNumber).ToString();
                        theBest[levelNumber] = newTime[levelNumber];
                    }
                }
                else
                {
                    theBest[levelNumber] = newTime[levelNumber];
                    PlayerPrefs.SetFloat("bestTime" + levelNumber, newTime[levelNumber]);
                    bestTime.text = PlayerPrefs.GetFloat("bestTime" + levelNumber).ToString();

                }
            }
        }
        else
        {
            theBest[levelNumber] = 0;
            bestTime.text = "0000";
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void getTime()
    {
        
    }
}
