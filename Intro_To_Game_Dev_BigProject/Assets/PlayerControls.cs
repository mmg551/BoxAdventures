using UnityEngine;
using System.Collections;

public class PlayerControlsupolished : MonoBehaviour {
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

    public LayerMask groundLayer;
    public float movementForce;
    Vector2 movementDirection = Vector2.zero;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float rayDistance = (transform.localScale.y * 0.5f) + 0.5f;
        onGround = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
       movement();
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

}
