using UnityEngine;
using System.Collections;

public class PlayerControlsunpolished : MonoBehaviour {
    bool jumping = false;
    bool onGround = true;
   bool goingLeft = false;
    bool goingRight = false;
    float startY;
    float curJmpVel;
    float curMovVel;
    public float jumpSpeed;
    public float moveSpeed;
    public float downSpeed;
    public float gravity; 
    public Rigidbody2D thePlayer;
    public Vector2 leftForce;
    public Vector2 rightForce;
    public Vector2 downForce;
    public Vector2 jumpForce;

    public LayerMask groundLayer;
    public float movementForce;
    Vector2 movementDirection = Vector2.zero;

	// Use this for initialization
	void Start () {
        startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        float rayDistance = (transform.localScale.y * 0.5f) + 0.5f;
        onGround = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
       movement();
       
       
//        if (goingLeft)
//        {
//            dealWithLeft();
//        }
//        if (goingRight)
//        {
//            dealWithRight();
//        }
       // shooting();
        if (jumping)
        {
            dealWithJumping();
        }
	}

    void FixedUpdate () {
        thePlayer.AddForce(movementDirection * movementForce);
    }

    void movement()
    {
//        if (!jumping)
//        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                jumps();
            }
//        }
//        else
//        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                goDown();
            }
//        }


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
//        onGround = false;
//        jumping = true;
//        curJmpVel = jumpSpeed; 

        if (onGround)
        {
            thePlayer.AddForce(jumpForce, ForceMode2D.Impulse);
        }

    }

    void moveLeft()
    {
        goingLeft = true;
        goingRight = false;
        curMovVel = moveSpeed;

    }

    void moveRight()
    {
        goingRight = true;
        goingLeft = false;
        curMovVel = -1 * moveSpeed;


    }

    void goDown()
    {
//       
        thePlayer.AddForce(downForce, ForceMode2D.Impulse);
       /* transform.position += new Vector3(transform.position.x, downSpeed, 0);
        if (transform.position.y < startY)
        {
            transform.position = new Vector3(transform.position.x, startY, 0);
        }*/
    }

    void dealWithJumping()
    {
//        thePlayer.AddForce(jumpForce, ForceMode2D.Impulse);
       // thePlayer.transform.position.y -= gravity;
        /*
        transform.position += new Vector3(curMovVel, curJmpVel, 0);
        curJmpVel -= gravity;
        if (transform.position.y < startY)
        {
            onGround = true;
            jumping = false;
            transform.position = new Vector3(transform.position.x, startY, 0);
        }*/
    }
     void  dealWithLeft()
    {
//        curMovVel = 1;
//            thePlayer.AddForce(curMovVel * leftForce, ForceMode2D.Impulse);
            //transform.position += new Vector3(curMovVel, startY, 0);

        /*if(!onGround)
        {
            transform.position += new Vector3(curMovVel, transform.position.y, 0);
        }
        if (transform.position.y < startY)
        {
            transform.position = new Vector3(transform.position.x, startY, 0);
        }*/
    }

    void dealWithRight()
    {
//        curMovVel = 1;
//        thePlayer.AddForce(curMovVel * rightForce, ForceMode2D.Impulse);
       /* if (onGround)
        {
            transform.position += new Vector3(curMovVel, startY, 0);
        }
        if (!onGround)
        {
            transform.position += new Vector3(curMovVel, transform.position.y, 0);
        }
        if (transform.position.y < startY)
        {
            transform.position = new Vector3(transform.position.x, startY, 0);
        }*/
    }

}
