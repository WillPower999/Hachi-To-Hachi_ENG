using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    const int MAXPOSSHP = 6; //This way, we can change the max possible HP without having to change the value everywhere we need it
    
    public Image[] healthPoints;
    public Sprite[] healthStatus;
    // 0 = empty, 1 = full

    PlayerHealth playerHealth;
    int maxhealth;
    int health;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.health;
        maxhealth = playerHealth.maxhealth;

        for (int index = 0; index <= MAXPOSSHP; index++)
        {
            if (index + 1 < health) healthPoints[index].sprite = healthStatus[1];
            else if (index + 1 > maxhealth) healthPoints[index].gameObject.SetActive(false);
            else healthPoints[index].sprite = healthStatus[0];
        }
    }
}
