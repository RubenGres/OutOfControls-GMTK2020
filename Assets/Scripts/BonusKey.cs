using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusKey : MonoBehaviour
{
    public string value;
    public AudioSource audio;

    void OnTriggerEnter2D(Collider2D other)
    {
        audio.Play();
        switch (value)
        {
            case "up":
                ControlLimit.currentControlLimit.up++;
                break;

            case "left":
                ControlLimit.currentControlLimit.left++;
                break;

            case "right":
                ControlLimit.currentControlLimit.right++;
                break;
        }

        this.gameObject.SetActive(false);
    }
}
