using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
    bool onGround = true;
    float curJmpVel;
   
    public float jumpSpeed;
    public float moveSpeed;
    public float downSpeed;
    public float gravity; 
    public Rigidbody2D thePlayer;
    public Vector2 leftForce;
    public Vector2 rightForce;
    public Vector2 downForce;
    public Vector2 jumpForce;
    public float dashForce;
    public LayerMask groundLayer;
    public float movementForce;
    Vector2 movementDirection = Vector2.zero;
    Vector2 dashDirection = Vector2.zero; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float rayDistance = (transform.localScale.y * 0.5f) + 0.5f;
        onGround = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
       movement();
        dash();
	}

    void FixedUpdate () {
        thePlayer.AddForce(movementDirection * movementForce);

    }

    void movement()
    {
            if (Input.GetKeyDown(KeyCode.W))
            {
                jumps();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                goDown();
            }


        int x = BoolToInt(Input.GetKey(KeyCode.D)) - BoolToInt(Input.GetKey(KeyCode.A));
        movementDirection = new Vector2(x, 0);

    }

    int BoolToInt (bool b) {
        if (b == true)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    void jumps()
    {

        if (onGround)
        {
            thePlayer.AddForce(jumpForce, ForceMode2D.Impulse);
        }

    }
        
    void goDown()
    {
        thePlayer.AddForce(downForce, ForceMode2D.Impulse);
       
    }

    void dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoDash();


        }
        //right 1,0
        //up 0,1
        //
    }

    void GoDash()
    {
        int x = BoolToInt(Input.GetKey(KeyCode.D)) - BoolToInt(Input.GetKey(KeyCode.A));
        int y  = BoolToInt(Input.GetKey(KeyCode.W)) - BoolToInt(Input.GetKey(KeyCode.S));
        dashDirection = new Vector2(dashForce * x, dashForce * y);
        thePlayer.AddForce(dashDirection, ForceMode2D.Impulse);

    }
}
