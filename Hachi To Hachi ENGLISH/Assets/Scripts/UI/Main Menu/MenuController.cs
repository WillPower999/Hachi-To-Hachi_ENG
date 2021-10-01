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
    [SerializeField] private GameObject noSavedGameDialogue = null;

    public void NewGameDialogueYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGameDialogueYes()
    {
        /*if(there are saved files)
        {
        then ask which one;
        }
        else
        {
        NoSavePanel_Dialogue.SetActive(true);
        }
        */
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
