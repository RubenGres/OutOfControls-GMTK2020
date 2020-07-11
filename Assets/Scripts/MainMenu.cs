using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void startGame()
    {
        GameManager.loadLevel();
    }

    public void levelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void exit()
    {
        Application.Quit();
    }


}
