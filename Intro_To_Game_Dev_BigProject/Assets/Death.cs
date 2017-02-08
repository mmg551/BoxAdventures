using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {
    public string SceneName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "death")
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
