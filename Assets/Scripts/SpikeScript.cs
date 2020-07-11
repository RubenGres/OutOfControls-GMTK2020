using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.reloadScene();
    }
}
