﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    public static Sound me;
    public GameObject audSource;
    public AudioSource[] audSources;
	// Use this for initialization
    void Awake()
    {
        me = this;
    }
	void Start () {
        
        audSources = new AudioSource[32];
        for (int i = 0; i < audSources.Length; i++)
        {
            
            audSources[i] = (Instantiate(audSource, Vector3.zero, Quaternion.identity) as GameObject).GetComponent<AudioSource>();
        }
	}

    public void PlaySound(AudioClip snd, float vol)
    {
        int sNum = GetSourceNum();
        audSources[sNum].clip = snd;
        audSources[sNum].volume = vol;
        audSources[sNum].Play();
    }
	// Update is called once per frame
    public int GetSourceNum()
    {
        for (int i = 0; i < audSources.Length; i++)
        {
            if (!audSources[i].isPlaying)
            {
                return i;
            }

        }
        return 0;
    }

}
