using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class GameSave 
{
    public int maxhealth;
    public int brickcount;
    public bool[] bricks;
    public Vector3 checkpointlocation;
    public int squealcount;
    public bool[] squeals;
    public bool orb;
    //public int orbcount;
    public int gDaifukucount;
    public bool[] gDaifuku;
    public string currentlevel;
}
