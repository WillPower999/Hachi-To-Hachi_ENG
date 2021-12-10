using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locationswitch : MonoBehaviour
{
    //public GameObject player;
    public GameObject spawn;

    void OnTriggerEnter(Collider player)
    {
        player.gameObject.transform.position = spawn.transform.position;
    }
}