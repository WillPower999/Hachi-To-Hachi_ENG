using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameSave readFile()
    {
        string gamesave = File.ReadAllText($"{Application.persistentDataPath}/savefile.json", System.Text.Encoding.UTF8);
        GameSave loadedfile = JsonUtility.FromJson<GameSave>(gamesave);
        Debug.Log(loadedfile.maxhealth);
    }

    public void writeFile()
    {
        GameSave save = new GameSave();
        save.brickcount = 4;
        save.maxhealth = 3;
        string json = JsonUtility.ToJson(save);
        Debug.Log(json);
        File.WriteAllText($"{Application.persistentDataPath}/savefile.json", json);
        Debug.Log(Application.persistentDataPath);
    }
}
