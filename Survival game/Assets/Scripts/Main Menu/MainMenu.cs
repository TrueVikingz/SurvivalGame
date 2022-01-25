using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Made after https://www.youtube.com/watch?v=RsgiYqLID-U&ab_channel=CocoCode
    
    
    public void ExitBubutton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
