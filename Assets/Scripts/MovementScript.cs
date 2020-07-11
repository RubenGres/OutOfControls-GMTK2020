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

    ControlLimit limit;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        //remove "level" from the scene name
        int level = Int16.Parse(SceneManager.GetActiveScene().name.Remove(0,5));

        limit = ControlLimit.getLevelLimit(level);
    }

    void Update()
    {

        if (Input.GetKeyDown("up"))
            if (isGrounded())
                if (limit.up > 0)
                {
                    limit.up--;
                    up();
                }

        if (Input.GetKeyDown("left"))
            if(isMoving())
                if (limit.left > 0)
                {
                    limit.left--;
                    left();
                }

        if (Input.GetKeyDown("right"))
            if (isMoving())
                if (limit.right > 0)
                {
                    limit.right--;
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
        Vector3 raycast = transform.position - new Vector3(0, transform.lossyScale.y/2 - 0.001f, 0);
        RaycastHit2D hit = Physics2D.Raycast(raycast, -Vector2.up, Mathf.Infinity);
        if (hit.collider != null)
        {
            Debug.DrawLine(raycast, hit.point, Color.red);
            Debug.Log(hit.distance);
            return hit.distance < 0.2;
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