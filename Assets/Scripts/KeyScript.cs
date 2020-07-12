using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject door;
    public AudioSource audio;
    private void OnTriggerEnter2D(Collider2D other)
    {
        audio.Play();
        this.transform.gameObject.SetActive(false);
        door.GetComponent<DoorScript>().close();
    }
}
