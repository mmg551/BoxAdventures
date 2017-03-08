using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalBoss : MonoBehaviour {
    Vector3 startHere;
    Vector3 endHere;
    public Rigidbody2D thePlayer;
    public float endDistance;
    public float speed;
    public float fastSpeed;
    public float finalStretchSpeed;
    float increment = 0;
	// Use this for initialization
	void Start () {
        startHere = transform.position;
        endHere = startHere + (Vector3.right * endDistance);
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameObject.FindGameObjectWithTag("pause").GetComponent<PauseScreen>().Paused)
        {
            transform.position = Vector3.Lerp(startHere, endHere, increment);
            increment += speed;
            if (thePlayer.transform.position.x > 0)
            {
                speed = 0;
                increment += fastSpeed;
            }
            if (thePlayer.transform.position.x > 4000)
            {
                speed = 0;
                fastSpeed = 0;
                increment += finalStretchSpeed;
            }
        }
    }
}
