using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingPlatform : MonoBehaviour {
    public bool nowClimb = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            nowClimb = true;
        }
    }
    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            nowClimb = false;
        }
    }
}
