using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberWallScript : MonoBehaviour
{
    public GameObject player;
    private MovementScript ms;

    private void Start()
    {
        ms = player.GetComponent<MovementScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ms.bounce();
    }
}
