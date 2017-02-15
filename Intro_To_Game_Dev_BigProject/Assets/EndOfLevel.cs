using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour {
    public GameObject victoryScreen;
    public GameObject mycamera;
    public GameObject theTimer;
    public Text yourTime;
    public Text otherTime;
    public int levelNumber;
    bool over = false;
    bool again = false;
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
        PlayerPrefs.SetFloat("bestTime" + levelNumber, myTime.time);
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
            yourTime = otherTime;
        }
    }

    void retry()
    {
        
    }
    public void Overworld(int overworld)
    {

        Time.timeScale = 1.0f;
        victoryScreen.gameObject.SetActive (false);
        SceneManager.LoadScene(overworld);


    }

    void sceneChanging()
    {
        if (over == true)
        {
            SceneManager.LoadScene(1);
        }

        if (again == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void TryAgain ()
    {
        
        Time.timeScale = 1.0f;
        //loads scene of whatever number i put in the box 
        victoryScreen.gameObject.SetActive (false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
}
