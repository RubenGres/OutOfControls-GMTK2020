using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{

    private float speed = 1f;
    private float amplitude = 0.01f;

    private Vector3 scaleStart;
    private void Start()
    {
        scaleStart = transform.transform.localScale;
    }

    void FixedUpdate()
    {
        Vector3 newScale = scaleStart;
        float s = Mathf.Sin(Time.frameCount * Time.deltaTime * speed) * amplitude;
        newScale += new Vector3(s, s, s);
        transform.localScale = newScale;
    }
}
