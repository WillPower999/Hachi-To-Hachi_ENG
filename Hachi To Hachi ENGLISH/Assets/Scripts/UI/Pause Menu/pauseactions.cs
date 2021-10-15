using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseactions : MonoBehaviour
{
    KeyCode pausekey = KeyCode.M;
    public GameObject PauseContainer;
    
    void Update()
    {
        if (Input.GetKeyDown(pausekey))
        {
            PauseContainer.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        PauseContainer.SetActive(false);
    }
    public void ExitToDesktop()
    {
        Application.Quit();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(GlobalGameState.currentGame.scene);
    }

}
