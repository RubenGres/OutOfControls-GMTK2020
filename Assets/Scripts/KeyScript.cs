using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject door, key;
    private void OnTriggerEnter2D(Collider2D other)
    {
        key.SetActive(false);
        door.SetActive(false);
    }
}
