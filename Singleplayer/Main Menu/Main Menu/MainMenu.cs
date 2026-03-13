using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Scene LevelSelect;
   public void OnPlayButton()
   {
       SceneManager.LoadScene("LevelSelection");
   }

    public void OnSettingsButton() 
    {
        SceneManager.LoadScene("Settings");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnBackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
