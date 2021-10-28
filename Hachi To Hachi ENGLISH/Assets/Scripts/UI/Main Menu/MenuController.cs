using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuController : MonoBehaviour
{
    public string _newGameLevel;
    [Header("Pop Up Menus")]
    public GameObject ExistingFileMenu;
    public GameObject NewFileMenu;
    [SerializeField] private GameObject noSavedGameDialogue = null;
    [SerializeField] private SaveSlotButton[] savebuttons;

    int save;

    public void Start()
    {

        for(int index = 0; index < savebuttons.Length; index++)
        {
            savebuttons[index].Initialize(index, GameNotExist, GameExists);
        }
    }
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
    
    public void GameExists(int index)
    {
        ExistingFileMenu.SetActive(true);
        save = index;
    }

    public void GameNotExist(int index)
    {
        NewFileMenu.SetActive(true);
        save = index;
    }
    
    public void Clearsave()
    {
        save = -1;
    }


    public void CreateGame()
    {
        Debug.Log("Create Game" + save);
        GameSave newGame = new GameSave();
        newGame.SaveSlotIndex = save;
        newGame.setupNewGame();
        string json = JsonUtility.ToJson(newGame);
        File.WriteAllText($"{Application.persistentDataPath}/save{save}.json", json);
        GlobalGameState.currentGame = newGame;
        Debug.Log(_newGameLevel);
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGame()
    {
        Debug.Log("Load Game" + save);
        string gamesave = File.ReadAllText($"{Application.persistentDataPath}/save{save}.json", System.Text.Encoding.UTF8);
        GameSave loadedfile = JsonUtility.FromJson<GameSave>(gamesave);
        Debug.Log(Application.persistentDataPath);
        GlobalGameState.currentGame = loadedfile;
        SceneManager.LoadScene(GlobalGameState.currentGame.scene);
    }
}
