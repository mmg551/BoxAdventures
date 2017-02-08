using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndOfLevel : MonoBehaviour {
    public GameObject victoryScreen;
    public GameObject mycamera;
    public GameObject theTimer;

    Timer myTime;
	// Use this for initialization
	void Start () {
       
        myTime = theTimer.GetComponent<Timer>(); 
        victoryScreen.gameObject.SetActive (false);
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Savetime()
    {
        Debug.Log(myTime);
        PlayerPrefs.SetFloat("bestTime", myTime.time);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Savetime();
            Debug.Log("anything");
            Debug.Log(myTime.time);
            Time.timeScale = 0.0f;
            victoryScreen.gameObject.SetActive(true);
        }
    }
}
