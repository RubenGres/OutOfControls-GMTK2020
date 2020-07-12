using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2Script : MonoBehaviour
{
    public GameObject door1, door2, key;
    public AudioSource audio;
    private void OnTriggerEnter2D(Collider2D other)
    {
        audio.Play();
        key.SetActive(false);
        door1.SetActive(false);
        door2.SetActive(false);
    }
}
