using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MaınMenuManager : MonoBehaviour
{
     /*void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        }
        else
        {
            PlayerPrefs.SetInt("Level", 1);
            SceneManager.LoadScene(1);
        }
    }*/
    public void TapToPlay()
    {

        if (PlayerPrefs.HasKey("Level"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
            Time.timeScale = 1;
        }
        else
        {
            PlayerPrefs.SetInt("Level", 1);
            SceneManager.LoadScene(1);
        }
    }

    
}
