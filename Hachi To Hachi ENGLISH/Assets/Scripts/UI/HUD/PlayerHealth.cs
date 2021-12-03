using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthbar;

    public void TakeDamage(int damage)
    {
        //GlobalGameState.currentGame.health -= damage;
        healthbar.UpdateUI();
    }

    public void GainHealth(int heal)
    {
        GlobalGameState.currentGame.health = Mathf.Min(GlobalGameState.currentGame.health + heal, GlobalGameState.currentGame.maxhealth);
        healthbar.UpdateUI();
    }
    public void GainGTakoyaki()
    {
        GlobalGameState.currentGame.gDaifukucount++;
        if(GlobalGameState.currentGame.gDaifukucount %4 == 0)
            GlobalGameState.currentGame.maxhealth++;
    }
    public void gainBrick()
    {
        GlobalGameState.currentGame.brickcount += 1;
        BrickCountingUI.Instance.UpdateUI();
    }
}


