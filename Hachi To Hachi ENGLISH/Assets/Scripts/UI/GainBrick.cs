using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainBrick : MonoBehaviour
{
    public void addBrick()
    {
        PlayerHealth playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerStats.gainBrick();
    }
}

