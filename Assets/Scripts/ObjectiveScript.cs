using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.nextLevel();
    }
}
