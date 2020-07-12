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

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        //Debug.Log("up " + limit["up"] + ", left " + limit["left"] + ", right" + limit["right"]);
    }

    public void up()
    {
        // jump if on ground
        rb.AddForce(Vector3.up * jumpForce);
    }

    public void left()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    public void right()
    {
        rb.velocity = new Vector2(+speed, rb.velocity.y);
    }

    bool isGrounded()
    {
        Vector3 raycast = transform.position - new Vector3(transform.lossyScale.x / 2, transform.lossyScale.y/2 - 0.001f, 0);
        RaycastHit2D hit1 = Physics2D.Raycast(raycast, -Vector2.up, Mathf.Infinity);

        Vector3 raycast2 = transform.position - new Vector3(-transform.lossyScale.x / 2, transform.lossyScale.y / 2 - 0.001f, 0);
        RaycastHit2D hit2 = Physics2D.Raycast(raycast2, -Vector2.up, Mathf.Infinity);


        if (hit1.collider != null || hit2.collider)
        {
            Debug.DrawLine(raycast, hit1.point, Color.red);
            Debug.DrawLine(raycast2, hit2.point, Color.red);
            return hit1.distance < 0.2 || hit2.distance < 0.2;
        }

        return false;
    }

    bool isMoving()
    {
        return Mathf.Abs(rb.velocity.x) < 0.01;
    }

    public void bounce()
    {
        if (rb.velocity.x > 0)
        {
            left();
        }
        else
        {
            right();
        }
    }

    public void bump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        up();
    }

}