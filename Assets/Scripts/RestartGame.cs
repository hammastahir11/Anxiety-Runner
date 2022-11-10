using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//In this script Game restart and exit functionality is working properly
public class RestartGame : MonoBehaviour
{



    public void RestartThisGame()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
