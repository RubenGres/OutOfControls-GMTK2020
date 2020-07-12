using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TactileInput : MonoBehaviour
{

    public GameObject player;

    public void up()
    {
        player.GetComponent<MovementScript>().up();
    }

    public void left()
    {
        player.GetComponent<MovementScript>().left();
    }
    public void right()
    {
        player.GetComponent<MovementScript>().right();
    }

    public void reload()
    {
        GameManager.reloadScene();
    }

    public void esc()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
