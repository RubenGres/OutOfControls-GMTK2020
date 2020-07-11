using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterControlUI : MonoBehaviour
{
    controlUI UI_up, UI_left, UI_right;

    // Start is called before the first frame update
    void Start()
    {
        UI_up = transform.Find("UI_up").GetComponent<controlUI>();
        UI_left = transform.Find("UI_left").GetComponent<controlUI>();        
        UI_right = transform.Find("UI_right").GetComponent<controlUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UI_up.count = ControlLimit.currentControlLimit.up;
        UI_left.count = ControlLimit.currentControlLimit.left;
        UI_right.count = ControlLimit.currentControlLimit.right;
    }
}
