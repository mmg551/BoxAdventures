using UnityEngine;
using System.Collections;

public class UpsideDownPlatform : MonoBehaviour {
//    public bool isTrigger; 
    public Rigidbody2D thePlayer;
   
    public bool climbing;
    public Vector2 upsideDownForce;
    public Collider2D myBox;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (climbing == true)
        {
            upsideDown();
            if (Input.GetKeyDown(KeyCode.W))
            {
                thePlayer.AddForce(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().jumpForce, ForceMode2D.Impulse);
            }
           
        }



	}
    void FixedUpdate()
    {
        
       
    }

   

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("hi");
//            isTrigger = true;
            climbing = true;
            upsideDown();

        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            climbing = true;
            upsideDown();

        }

    }




    void OnTriggerExit2D(Collider2D c)
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            thePlayer.AddForce(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().jumpForceHold, ForceMode2D.Impulse);
        }
    }
}
