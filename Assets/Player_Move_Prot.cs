using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour
{

    float moveX;
    public int playerspeed = 50;
    private bool facingRight = false;
    public int playerJumpPower = 1250;
    private bool isGrounded;
    private Rigidbody2D myRig;
    public float base_speed = 3.0f;
    public float max_speed = 6.0f;

    // Use this for initialization
    void Start()
    {
        myRig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        //ANIMATIONS
        //PLAYER DIRECTION
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        //PHYSICS
        myRig.velocity = new Vector2(moveX * playerspeed, myRig.velocity.y);
        //Attempt at momentum
        //if (myRig.velocity.x < max_speed)
        // {
        //     myRig.velocity = new Vector2(1 * Time.deltaTime, myRig.velocity.y);
        // }
        //else if (myRig.velocity.x > base_speed)
        // {
        //     myRig.velocity = new Vector2 (-(1 * Time.deltaTime), myRig.velocity.y);
        //}
    }

    void Jump()
    {
        //JUMPING COD
        if (isGrounded)
        {
            isGrounded = true;
        }
        myRig.AddForce(Vector2.up * playerJumpPower);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Collider2D>().tag == "floor")
        {
            isGrounded = true;
        }
    }
}