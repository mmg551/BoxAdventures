using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour {

    public Canvas preview;
    public Canvas number;
    public int level;

	// Use this for initialization
	void Start () {
        number.gameObject.SetActive(true);
        preview.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void enterLevel(int theLevel)
    {
            SceneManager.LoadScene(theLevel);


    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            number.gameObject.SetActive(false);
            preview.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("hello");


            }

        }
    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            number.gameObject.SetActive(true);
            preview.gameObject.SetActive(false);
        }
    }
        
}
