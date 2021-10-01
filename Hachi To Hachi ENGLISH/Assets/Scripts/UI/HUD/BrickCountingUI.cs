using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickCountingUI : MonoBehaviour
{
    public static BrickCountingUI Instance;

    public Text counter;
    BrickCounter brickcounter;
    int bricks;
    PlayerHealth playerStats;

    private void Start()
    {
        Instance = this;
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }
    // Update is called once per frame
 /*   void Update()
    {
        bricks = playerStats.brickcount;

        counter.text = "X " + bricks;
    }*/

    public void UpdateUI()
    {
        bricks = playerStats.brickcount;

        counter.text = "X " + bricks;
    }
}
