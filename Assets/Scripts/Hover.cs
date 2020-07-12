using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [Range(0, 5)]
    public float speed;

    [Range(0, 1)]
    public float amplitute;

    private Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 newPos = originalPos;
        newPos.y += (Mathf.Sin(Time.frameCount * Time.deltaTime * speed) + 1) * amplitute;
        transform.position = newPos;
    }
}
