using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class GameSave 
{
    public int SaveSlotIndex;
    
    //health
    public int health;  //1
    public int maxhealth;  //1
   
    //collectables
    public int brickcount; //1
    public bool[] bricks;
    public int squealcount;
    public bool[] squeals;

    //public int orbcount;
    public bool orb;
    public int gDaifukucount; //1
    public bool[] gDaifuku;

    //location
    public Vector3 checkpointlocation;
    public string currentlevel;

    //ammo
    public int inkammo;
    public int honeyammo;

    //instantiation
    public void setupNewGame()
    {
            gDaifukucount = 0;
            health = 5;
            maxhealth = 5;
            brickcount = 0;
    }
}


