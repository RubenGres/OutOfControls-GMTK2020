using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public float jumpForce;

    bool goesRight = false;

    public GameObject ControlUI;


    ControlLimit limit;
    controlUI UI_up, UI_left, UI_right;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        //remove "level" from the scene name
        int level = Int16.Parse(SceneManager.GetActiveScene().name.Remove(0,5));

        limit = ControlLimit.getLevelLimit(level);
        UI_up = ControlUI.transform.Find("UI_up").GetComponent<controlUI>();
        UI_up.count = limit.up;
        UI_left = ControlUI.transform.Find("UI_left").GetComponent<controlUI>();
        UI_left.count = limit.left;
        UI_right = ControlUI.transform.Find("UI_right").GetComponent<controlUI>();
        UI_right.count = limit.right;
    }

    void Update()
    {

        if (Input.GetKeyDown("up"))
            if (isGrounded())
                if (limit.up > 0)
                {
                    limit.up--;
                    UI_up.count--;
                    up();
                }

        if (Input.GetKeyDown("left"))
            if(isMoving())
                if (limit.left > 0)
                {
                    limit.left--;
                    UI_left.count--;
                    left();
                }

        if (Input.GetKeyDown("right"))
            if (isMoving())
                if (limit.right > 0)
                {
                    limit.right--;
                    UI_right.count--;
                    right();
                }

        if(Input.GetKey(KeyCode.R))
        {
            GameManager.reloadScene();
        }

        //Debug.Log("up " + limit["up"] + ", left " + limit["left"] + ", right" + limit["right"]);
    }

    void up()
    {
        // jump if on ground
        rb.AddForce(Vector3.up * jumpForce);
    }

    void left()
    {
        goesRight = false;
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    void right()
    {
        goesRight = true;
        rb.velocity = new Vector2(+speed, rb.velocity.y);
    }

    bool isGrounded()
    {
        Vector3 raycast = transform.position - new Vector3(0, transform.lossyScale.y, 0);
        RaycastHit2D hit = Physics2D.Raycast(raycast, -Vector2.up, Mathf.Infinity);
        if (hit.collider != null)
        {
            Debug.DrawLine(raycast, hit.point, Color.red);
            return hit.distance < 0.01;
        }

        return false;
    }

    bool isMoving()
    {
        return Mathf.Abs(rb.velocity.x) < 0.01;
    }

    public void bounce()
    {
        if (goesRight)
        {
            left();
        }
        else
        {
            right();
        }
    }
}

/*
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

        
    }

    */