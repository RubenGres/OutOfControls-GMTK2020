using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberWallScript : MonoBehaviour
{
    public GameObject player;
    
    private MovementScript ms;
    private Material mat;
    private Color baseColor;

    private void Start()
    {
        ms = player.GetComponent<MovementScript>();
        mat = GetComponent<Renderer>().material;
        baseColor = mat.color;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ms.bounce();
        mat.SetColor("_EmissionColor", new Color(0.2f, 0.2f, 0.2f));

        transform.Find("Lights").gameObject.SetActive(true);

        StartCoroutine(resetColor());
    }

    IEnumerator resetColor()
    {
        yield return new WaitForSeconds(0.1f);

        mat.color = baseColor;
        transform.Find("Lights").gameObject.SetActive(false);
        mat.SetColor("_EmissionColor", Color.black);
    }
}
