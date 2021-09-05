using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenteBacata.ScivoloCharacterControllerDemo
{
    public class MovementManager : MonoBehaviour
    {
        public string movementMode = "Land";

        public GameObject Octo;
        public GameObject Bee;

        public Transform octoTarget;
        public Transform beeTarget;

        public Camera targetCamera;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (movementMode == "Land")
                {
                    targetCamera.gameObject.GetComponent<OrbitingCamera>().target = beeTarget;
                    movementMode = "Sky";
                    Octo.GetComponent<SimpleCharacterController>().enabled = false;
                    Bee.GetComponent<SkyMovement>().enabled = true;
                }
                else if (movementMode == "Sky")
                {
                    targetCamera.gameObject.GetComponent<OrbitingCamera>().target = octoTarget;
                    movementMode = "Land";
                    Octo.GetComponent<SimpleCharacterController>().enabled = true;
                    Bee.GetComponent<SkyMovement>().enabled = false;
                }
            }
        }
    }
}