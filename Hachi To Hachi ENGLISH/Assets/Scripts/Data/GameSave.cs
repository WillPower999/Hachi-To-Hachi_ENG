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
    public string scene;

    //ammo
    public int inkammo;
    public int honeyammo;

    //instantiation
    public void setupNewGame()
    {
        gDaifukucount = 0;
        health = 5;
        maxhealth = 5;
        bricks = new bool[6];
        brickcount = 0;
        for (int i = 0; i < bricks.Length; i++) bricks[i] = false;
        squealcount = 0;
        squeals = new bool[3];
        for (int i = 0; i < squeals.Length; i++) squeals[i] = false;
        orb = false;
        gDaifukucount = 0;
        gDaifuku = new bool[5];
        for (int i = 0; i < gDaifuku.Length; i++) gDaifuku[i] = false;
        checkpointlocation.x = 0;
        checkpointlocation.y = 0;
        checkpointlocation.z = 0;
        scene = "beta_eitto";
        inkammo = 0;
        honeyammo = 0;

    }
}


