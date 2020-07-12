using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float closingSpeed;

    private bool closing = false;

    void Update()
    {
        if(closing)
        {
            this.transform.localScale = this.transform.localScale - (Vector3.up * closingSpeed);
            if (transform.localScale.y < 0)
                transform.gameObject.SetActive(false);
        }

    }

    internal void close()
    {
        closing = true;
    }
}
