using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthbar;
    public int health = 5;
    public int maxhealth = 5;
    public int brickcount = 0;

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void GainHealth(int heal)
    {
        health = Mathf.Min(health + heal, maxhealth);
        healthbar.UpdateUI();
    }

    public void gainBrick()
    {
        brickcount += 1;
        BrickCountingUI.Instance.UpdateUI();
    }
}


