using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{

    public void OnLevel1Press()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnLevel2Press()
    {
        SceneManager.LoadScene("Level2");
    }

    public void OnLevel3Press() 
    {
        SceneManager.LoadScene("Level3");
    }

    public void OnLevel4Press() 
    {
        SceneManager.LoadScene("Level4");
    }

    public void OnLevel5Press()
    {
        SceneManager.LoadScene("Level5");
    }

    public void OnLevel6Press() 
    {
        SceneManager.LoadScene("Level6");
    }

}
