using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {
     
    public GameObject restartScreen;
    bool outOfBounds = false;
	// Use this for initialization
	void Start () {
        restartScreen.gameObject.SetActive(false); 

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            outOfBounds = true;
            FellOutOfBounds();
        }
    }

    void FellOutOfBounds()
    {
        if (outOfBounds == true)
        {
            restartScreen.gameObject.SetActive(true); 
            Time.timeScale = 0.0f;

        }

    }

    public void restartLevel()
    {
        Time.timeScale = 1.0f;
        restartScreen.gameObject.SetActive(false); 
        outOfBounds = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
