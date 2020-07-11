using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour
{
    public GameObject player;
    private MovementScript ms;

    private void Start()
    {
        ms = player.GetComponent<MovementScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ms.bump();
    }
}
