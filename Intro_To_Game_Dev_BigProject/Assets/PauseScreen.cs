﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour {

    public GameObject canvas;
    public GameObject camera;
    bool Paused = false;

	// Use this for initialization
	void Start () {
        canvas.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            if(Paused == true)
            {
                Time.timeScale = 1.0f;
                canvas.gameObject.SetActive (false);
                Paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                canvas.gameObject.SetActive (true);
                Paused = true;
            }
        }
	
	}
}