using UnityEngine;
using System.Collections;

public class UpsideDownPlatform : MonoBehaviour {
//    public bool isTrigger; 
    public Rigidbody2D thePlayer;
    public Collider2D square;
    public bool climbing;
    public Vector2 upsideDownForce;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (climbing == true)
        {
            upsideDown();
        }

	}
    void FixedUpdate()
    {
        
        if (climbing == true)
        {
            onTriggerEnter2D(square);
            upsideDown();
        }
    }

    void onTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("hi");
//            isTrigger = true;
            climbing = true;

        }
    }

    void onTriggerStay2D(Collider2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            climbing = true;

        }

    }




    void onTriggerExit2D(Collider2D c)
    {

        if(c.gameObject.tag == "Player")
        {
            climbing = false;
        }
    }

    void upsideDown()
    {
        Debug.Log("hit");
        thePlayer.AddForce(upsideDownForce, ForceMode2D.Force);
    }
}
