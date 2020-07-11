using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int level = 1;
    public static int nLevel = 21;

    public static Dictionary<int, bool> unlockedLevels = null;
    public static Dictionary<int, bool> completedLevels = null;

    void Start()
    {
        if(unlockedLevels == null || completedLevels == null)
            initDict();

        if (!isFirstLaunch())
        {
            loadProgress();
            return;
        }

        for (int i = 1; i <= 10; i++)
        {
            unlockedLevels[i] = true;
        }
    }

    static bool isFirstLaunch()
    {
        if (PlayerPrefs.GetString("unlocked", "") == "")
            return true;

        return false;
    }

    static void initDict()
    {
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
    }

    static void saveProgress()
    {
        List<int> unlocked = new List<int>();
        List<int> completed = new List<int>();

        foreach (var l in unlockedLevels.Keys)
        {
            if (unlockedLevels[l])
                unlocked.Add(l);
        }

        foreach (var l in completedLevels.Keys)
        {
            if (completedLevels[l])
                completed.Add(l);
        }

        string completedStr = string.Join(" ", completed);
        string unlockedStr  = string.Join(" ", unlocked);

        PlayerPrefs.SetString("completed", completedStr);
        PlayerPrefs.SetString("unlocked", unlockedStr);
    }

    static void loadProgress()
    {
        string unlocked = PlayerPrefs.GetString("unlocked", "");

        String[] unlockedSplit = unlocked.Split(' ');
        for (int i = 0; i < unlockedSplit.Length; i++)
        {
            int n = Int16.Parse(unlockedSplit[i]);
            unlockedLevels[n] = true;
        }

        string completed = PlayerPrefs.GetString("completed", "");
        if(completed != "")
        {
            String[] completedSplit = completed.Split(' ');
            for (int i = 0; i < completedSplit.Length; i++)
            {
                int n = Int16.Parse(completedSplit[i]);
                completedLevels[n] = true;
            }
        }
    }

    internal static void nextLevel()
    {
        completedLevels[level] = true;
        level++;
        unlockedLevels[level] = true;
        SceneManager.LoadScene("level" + level);

        saveProgress();
    }

    internal static void loadLevel()
    {
        SceneManager.LoadScene("level" + level);
    }

    internal static void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
