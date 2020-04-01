using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void Play()
    {
        SceneManager.LoadScene("Game Scene"); // loads game scene

    }

    public void Options()
    {

        SceneManager.LoadScene("Options Menu");  // loads instructions menu

    } 

    public void Controls()
    {
        SceneManager.LoadScene("Controls Menu"); // loads controls menu
    }

    public void Audio()
    {
        SceneManager.LoadScene("Audio Menu"); // loads controls menu
    }

    public void Restart()
    {
        SceneManager.LoadScene("ForestScene"); // loads game scene

    }

    public void Back()
    {

        SceneManager.LoadScene("Main Menu"); // loads main menu

    }
   

    public void Quit()
    {
        Application.Quit(); // quits the application

    }

}

