using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D other)
    {
        this.transform.gameObject.SetActive(false);
        door.GetComponent<DoorScript>().close();
    }
}
