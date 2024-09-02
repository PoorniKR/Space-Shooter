using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float horizontalMove;
    private bool moveRight;
    private bool moveLeft;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
        speed = 5f;
    }

    void Update()
    {
        Movement();
    }
    
    public void MoveUp()
    {
        rb.velocity = Vector2.up * speed;
    }

    public void MoveDown()
    {
        rb.velocity = Vector2.up * -speed;
    }

    public void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }

    public void pointerDownLeft()
    {
        moveLeft = true;
    }

    public void pointerUpLeft()
    {
        moveLeft = false;
    }

    public void pointerDownRight()
    {
        moveRight = true;
    }

    public void pointerUpRight()
    {
        moveRight = false;
    }

    void Movement()
    {
        if(moveLeft)
        {
            horizontalMove = -speed;
        }
        else if(moveRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }

   
}
