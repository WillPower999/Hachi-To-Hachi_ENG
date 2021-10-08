using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveSlotButton : MonoBehaviour
{
    private Action<int> OnClickCallBack;
    private int index;
    public void Initialize(int index, Action<int> CreateGame, Action<int> LoadGame)
    {
        this.index = index;
        if (File.Exists($"{Application.persistentDataPath}/save{index}.json"))
            OnClickCallBack = LoadGame;
        else
            OnClickCallBack = CreateGame;
    }

    public void OnClick()
    {
        OnClickCallBack.Invoke(index);
    }
}
