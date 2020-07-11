using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlUI : MonoBehaviour
{
    public int count;

    public GameObject[] arrowIcons;

    private TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            arrowIcons[i].SetActive(true);
        }

        if (count <= 3)
        {
            textMesh.text = "";

            for (int i = 0; i < 3 - count; i++)
            {
                arrowIcons[i].SetActive(false);
            }

        } else
        {
            textMesh.text = "" + count;
        }
    }
}
