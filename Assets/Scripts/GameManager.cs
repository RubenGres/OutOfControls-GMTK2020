using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int level = 1;
    public static int nLevel = 21;
    public static bool dictInitated = false;


    public static Dictionary<int, bool> unlockedLevels;
    public static Dictionary<int, bool> completedLevels;

    void Start()
    {
        if (dictInitated)
            return;

        unlockedLevels = new Dictionary<int, bool>();
        completedLevels = new Dictionary<int, bool>();

        for (int i = 1; i <= nLevel; i++)
        {
            unlockedLevels.Add(i, false);
            completedLevels.Add(i, false);
        }

        for (int i = 1; i <= 10; i++)
        {
            unlockedLevels[i] = true;
        }

        dictInitated = true;
    }

    internal static void nextLevel()
    {
        Debug.Log("add completed level");
        completedLevels[level] = true;
        Debug.Log(completedLevels[1]);
        level++;
        unlockedLevels[level] = true;
        SceneManager.LoadScene("level" + level);
    }

    internal static void loadLevel()
    {
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
