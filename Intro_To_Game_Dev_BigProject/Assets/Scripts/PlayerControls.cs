using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
    bool onGround = true;
    bool onClimb = false;
    bool isJumping = false;
    bool onWall = false;
    bool enemyHit = false;
     
    public Vector2 enemyKnockback;
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
    public Vector2 jumpForceHold;
    public float dashForce;
    public LayerMask groundLayer;
    public LayerMask climbLayer;
    public float movementForce;
    Vector2 movementDirection = Vector2.zero;
    Vector2 dashDirection = Vector2.zero; 
    public Vector2 wallNormal;
    public SpriteRenderer mySprite;
    public SpriteRenderer mySprite1;
    public SpriteRenderer mySprite2;
    public Vector2 wallForce;
    public Vector2 upsideDownForce;
    float LOP;
    float bufferTime = .066f;

	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
       
	}
	
	// Update is called once per frame
	void Update () {
        if (onGround)
        {
            LOP = 0;
        }
        else
        {
            LOP += Time.deltaTime;
        }
        float rayDistance = (transform.localScale.y * 0.5f) + 0.5f;
        onGround = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);

        Debug.Log("climb; " + onClimb);
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
        if (isJumping == true)
        {
            thePlayer.AddForce(jumpForceHold, ForceMode2D.Impulse);
        }
        if (onClimb == true)
        {
            thePlayer.AddForce(upsideDownForce, ForceMode2D.Force);
        }

    }

    void movement()
    {
        if (LOP < bufferTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                thePlayer.AddForce(jumpForce, ForceMode2D.Impulse);
               
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }
            
        if (Input.GetKey(KeyCode.W))
        {
            if (LOP < bufferTime)
            {
                jumps();
            }
            else
            {
                isJumping = false;
               
            }

        }
            if (Input.GetKeyDown(KeyCode.S))
            {
                goDown();
            }


        int x = BoolToInt(Input.GetKey(KeyCode.D)) - BoolToInt(Input.GetKey(KeyCode.A));
        movementDirection = new Vector2(x, 0);
        if (x < 0)
        {
            mySprite.flipX = true;
            mySprite1.flipX = true;
            mySprite2.flipX = true;
        }
        if (x > 0)
        {
           mySprite.flipX = false;
            mySprite1.flipX = false;
            mySprite2.flipX = false;
        }
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
        isJumping = true;
    }

    void WallJump (Vector2 wallNormal) {
        if (playerRB.velocity.y < 0)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
        }
        thePlayer.AddForce(new Vector2(wallForce.x * Mathf.Sign(wallNormal.x),wallForce.y), ForceMode2D.Impulse);
        Debug.Log("jumP");
    }
        
    void goDown()
    {
        thePlayer.AddForce(downForce, ForceMode2D.Impulse);
       
    }


    void dash()
    {
        if (onGround || onClimb)
        {
            inAirDashCount = 0;
        }
//        GameObject.FindGameObjectWithTag("climb").GetComponent<ClimbingPlatform>().nowClimb
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround ||onClimb )
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

    void ExitClimb()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            thePlayer.AddForce(upsideDownForce, ForceMode2D.Impulse);
        }
       
    }

    void EnemyCollision()
    {
        if (enemyHit == true)
        {
            
            thePlayer.AddForce(enemyKnockback, ForceMode2D.Impulse);
           
//                float x = 0;
//                x += Time.deltaTime;
//                float movFor = movementForce;
//                Debug.Log(x);
//                Debug.Log(movFor);
//                if (x < 2f)
//                {
//
////                    movementForce = 0;
//                }
//                if (x >=2f)
//                {
//                    Debug.Log("ooo");
//                    movementForce = movFor;


                
            }
           
        }


    void OnCollisionStay2D(Collision2D c)
    {
        if (c.gameObject.tag == "wall")
        {
            wallNormal = c.contacts[0].normal;
        }
        if (c.gameObject.tag == "climb")
        {
            ExitClimb();
        }
    }

    void OnCollisionEnter2D (Collision2D c) {
        if (c.gameObject.tag == "wall")
        {
            onWall = true;

        }
        if (c.gameObject.tag == "enemy")
        {
            thePlayer.AddForce(enemyKnockback, ForceMode2D.Impulse);
           enemyHit = true;
        }
        if (c.gameObject.tag == "climb")
        {

            onClimb = true;

        }
    }



    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "wall")
        {
            onWall = false;
        }

        if (c.gameObject.tag == "enemy")
        {
            
            EnemyCollision();
}
        if (c.gameObject.tag == "climb")
        {

            onClimb = false;
            ExitClimb();
        }
    }


}
