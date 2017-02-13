using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour {
    EndOfLevel victoryScreen; 
    public GameObject theScreen;
        
	// Use this for initialization
	void Start () {
        victoryScreen = theScreen.GetComponent<EndOfLevel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void changeToScene (int sceneToChange)
    {
       
        SceneManager.LoadScene(sceneToChange);//loads scene of whatever number i put in the box 
        victoryScreen.gameObject.SetActive (false);

    }

    public void Overworld(int overworld)
    {
        
        SceneManager.LoadScene(overworld);
        victoryScreen.gameObject.SetActive (false);
       

    }
}
