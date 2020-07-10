using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private RigidBody2D rb;
    private Boolean isGrounded;
    public float speed;
    public float jumpForce;

    void Start()
    {

    }

    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKey("up"))
            {
                rb.AddForce(Vector3.up * jumpForce);
                isGrounded = false;
            }
        }
    }

    void OnCollisionEnter2D()
    {
        isGrounded = true;
    }
}
