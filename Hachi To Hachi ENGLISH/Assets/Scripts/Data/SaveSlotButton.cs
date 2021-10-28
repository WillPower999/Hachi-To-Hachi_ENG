using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveSlotButton : MonoBehaviour
{
    private Action<int> OnClickCallBack;
    private int index;
    public void Initialize(int index, Action<int> GameNotExist, Action<int> GameExists)
    {
        this.index = index;
        if (File.Exists($"{Application.persistentDataPath}/save{index}.json"))
            OnClickCallBack = GameExists;
        else
            OnClickCallBack = GameNotExist;
    }

    public void OnClick()
    {
        OnClickCallBack.Invoke(index);
    }
}
