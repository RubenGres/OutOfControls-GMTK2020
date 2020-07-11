using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void startGame()
    {
        GameManager.nextLevel();
    }

    public void selectLevel()
    {
        string n = GetComponentInChildren<Text>().text;
        GameManager.level = Int16.Parse(n);
        SceneManager.LoadScene("level"+ n);
    }

    public void exit()
    {
        Application.Quit();
    }
}
