using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Called");

        for(int i = 1; i <= GameManager.nLevel; i++)
        {
            Transform level = transform.Find("level" + i);
            Button b = level.gameObject.GetComponent<Button>();

            Image img = level.gameObject.GetComponent<Image>();
            Color color;
            ColorUtility.TryParseHtmlString("#A4A1A1", out color);
            img.color = color;

            Text t = level.gameObject.GetComponentInChildren<Text>();
            Color color2;
            ColorUtility.TryParseHtmlString("#7D7D7D", out color2);
            t.color = color;


            level.Find("check").gameObject.SetActive(false);
            b.interactable = false;
        }

        foreach (var l in GameManager.unlockedLevels.Keys)
        {
            if (GameManager.unlockedLevels[l])
            {
                Transform level = transform.Find("level" + l);
                Button b = level.gameObject.GetComponent<Button>();

                Image img = level.gameObject.GetComponent<Image>();
                img.color = Color.white;

                Color color;
                Text t = level.gameObject.GetComponentInChildren<Text>();
                ColorUtility.TryParseHtmlString("#363636", out color);
                t.color = color;

                b.interactable = true;
            }
        }

        foreach (var l in GameManager.completedLevels.Keys)
        {
            if(GameManager.completedLevels[l])
            {
                Transform level = transform.Find("level" + l);
                level.Find("check").gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
