using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }

        if (Input.GetKeyDown(KeyCode.Menu))
        {
            StartGame();
        }
    }
    

    public void StartGame()
    {
        SceneManager.LoadScene("MAin");
    }
    public void ExitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
