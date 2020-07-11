using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int level = 0;

    void Start()
    {
        
    }

    internal static void nextLevel()
    {
        level++;
        SceneManager.LoadScene("level" + level);
    }

    internal static void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
