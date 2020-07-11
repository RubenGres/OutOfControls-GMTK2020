using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusControl : MonoBehaviour
{
    public string value;

    void OnTriggerEnter2D(Collider2D other)
    {
        switch(value)
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
