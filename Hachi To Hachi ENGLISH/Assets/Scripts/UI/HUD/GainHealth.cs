using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainHealth : MonoBehaviour
{
    public void onTriggerEnter()
    {
        GlobalGameState.currentGame.health++;
        Destroy(this);
    }
}
