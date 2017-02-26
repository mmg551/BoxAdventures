using UnityEngine;
using System.Collections;

public class Global : MonoBehaviourSingleton<Global> {
    public static Global me;

	// Use this for initialization

    private void Awake()
    {
        me = this;
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
