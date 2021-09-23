using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickCountingUI : MonoBehaviour
{
    public Text counter;
    BrickCounter brickcounter;
    int bricks;
    PlayerHealth playerStats;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }
    // Update is called once per frame
    void Update()
    {
        bricks = playerStats.brickcount;

        counter.text = "X " + bricks;
    }
}
