﻿using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
    bool onGround = true;
    bool onWall = false;
    int inAirDashCount = 0;
    float curJmpVel;
    Rigidbody2D playerRB;
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
    public Vector2 wallNormal;
	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float rayDistance = (transform.localScale.y * 0.5f) + 0.5f;
        onGround = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
        //Debug.Log("ground; " + onGround);
       movement();
        dash();
        if (onWall == true )
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                WallJump(wallNormal);


            }
        }
	}

    void FixedUpdate () {
        thePlayer.AddForce(movementDirection * movementForce);

    }

    void movement()
    {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (onGround)
                {
                    jumps();
                }
               
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                goDown();
            }


        int x = BoolToInt(Input.GetKey(KeyCode.D)) - BoolToInt(Input.GetKey(KeyCode.A));
        movementDirection = new Vector2(x, 0);
//        if (x < 0)
//        {
//          
//        }
//        if (x > 0)
//        {
//
//        }
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
        thePlayer.AddForce(jumpForce, ForceMode2D.Impulse);
    }

    void WallJump (Vector2 wallNormal) {
        if (playerRB.velocity.y < 0)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
        }
        thePlayer.AddForce(jumpForce + (wallNormal * (jumpForce.y * 0.5f)), ForceMode2D.Impulse);
        Debug.Log("jumP");
    }
        
    void goDown()
    {
        thePlayer.AddForce(downForce, ForceMode2D.Impulse);
       
    }

    void dash()
    {
        if (onGround)
        {
            inAirDashCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                GoDash();
            }
            else
            {
                if (inAirDashCount < 1)
                {
                    GoDash();
                    inAirDashCount++;
                }
            }



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

    void OnCollisionStay2D(Collision2D c)
    {
        if (c.gameObject.tag == "wall")
        {
            wallNormal = c.contacts[0].normal;
        }
    }

    void OnCollisionEnter2D (Collision2D c) {
        if (c.gameObject.tag == "wall")
        {
            onWall = true;

        }
    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "wall")
        {
            onWall = false;
        }
    }
}
