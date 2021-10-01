using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels to Load")]
    public string _newGameLevel;
    private string levelToLoad;

    public void NewGameDialogueYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGameDialogueYes()
    {
        levelToLoad = 
    }
}
