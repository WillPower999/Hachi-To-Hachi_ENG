using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    const int MAXPOSSHP = 6; //This way, we can change the max possible HP without having to change the value everywhere we need it

    private const int EMPTY = 0;
    private const int FULL = 1;

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
    public void UpdateUI()
    {
        health = playerHealth.health;
        maxhealth = playerHealth.maxhealth;

        for (int index = 0; index < MAXPOSSHP; index++)
        {
            healthPoints[index].sprite = index < health ? healthStatus[FULL] : healthStatus[EMPTY];
            healthPoints[index].gameObject.SetActive(index < maxhealth);
            /*
            if (index + 1 < health) healthPoints[index].sprite = healthStatus[1];
            else if (index + 1 > maxhealth) healthPoints[index].gameObject.SetActive(false);
            else healthPoints[index].sprite = healthStatus[0];
            */
        }
    }
}
