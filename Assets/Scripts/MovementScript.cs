using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movement;
    private Boolean isGrounded;

    public float acceleration;
    public float friction;
    public float jumpForce;
    public float maxSpeed;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // jump if on ground
        if (isGrounded)
        {
            if (Input.GetKey("up"))
            {
                rb.AddForce(Vector3.up * jumpForce);
                isGrounded = false;
            }
        }

        leftRightMovement();

        if(Input.GetKey(KeyCode.R))
        {
            GameManager.reloadScene();
        }
    }

    void leftRightMovement()
    {
        if (Input.GetKey("left"))
        {
            movement -= acceleration;
        }
        else if (Input.GetKey("right"))
        {
            movement += acceleration;
        }
        else
        {
            if (Mathf.Abs(movement) <= friction + 0.1)
            {
                movement = 0;
            }
            else
            {
                if (movement > 0)
                {
                    movement -= friction;
                }
                else
                {
                    movement += friction;
                }
            }
        }

        if (Mathf.Abs(movement) > maxSpeed)
        {
            if (movement > 0)
            {
                movement = maxSpeed;
            }
            else
            {
                movement = -maxSpeed;
            }
        }

        rb.velocity = new Vector2(movement, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
