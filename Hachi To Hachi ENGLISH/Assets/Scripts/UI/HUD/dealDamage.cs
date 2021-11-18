using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealDamage : MonoBehaviour
{
    public void sendDamage(int dam)
    {
        PlayerHealth playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerStats.TakeDamage(dam);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //GlobalGameState.currentGame.health--;
            Debug.Log(GlobalGameState.currentGame.health);
        }
    }
}
