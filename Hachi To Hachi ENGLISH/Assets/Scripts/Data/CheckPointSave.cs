using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CheckPointSave : MonoBehaviour
{

    public void SaveGame()
    {
        GameSave gamesave = GlobalGameState.currentGame;
        string json = JsonUtility.ToJson(gamesave);
        Debug.Log(json);
        File.WriteAllText($"{Application.persistentDataPath}/savefile{GlobalGameState.currentGame.SaveSlotIndex}.json", json);
        Debug.Log(Application.persistentDataPath);
    }
}
