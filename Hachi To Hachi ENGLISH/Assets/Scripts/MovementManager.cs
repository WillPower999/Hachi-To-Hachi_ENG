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

        public GameObject beeBody;
        public GameObject beeHead;

        public Camera targetCamera;

        public SimpleCharacterController playerScript;

        // Start is called before the first frame update
        void Start()
        {
            playerScript = Octo.GetComponent<SimpleCharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (movementMode == "Land" && playerScript.verticalSpeed == 0f)
                {
                    targetCamera.gameObject.GetComponent<OrbitingCamera>().target = beeTarget;
                    movementMode = "Sky";
                    Octo.GetComponent<SimpleCharacterController>().enabled = false;
                    Bee.GetComponent<SkyMovement>().enabled = true;

                    beeBody.GetComponent<SphereCollider>().enabled = true;
                    beeHead.GetComponent<BoxCollider>().enabled = true;
                    //Bee.gameObject.GetComponent<SphereCollider>().enabled = true;
                    //Bee.gameObject.GetComponent<BoxCollider>().enabled = true;
                }
                else if (movementMode == "Sky")
                {
                    targetCamera.gameObject.GetComponent<OrbitingCamera>().target = octoTarget;
                    movementMode = "Land";
                    Octo.GetComponent<SimpleCharacterController>().enabled = true;
                    Bee.GetComponent<SkyMovement>().enabled = false;

                    beeBody.GetComponent<SphereCollider>().enabled = false;
                    beeHead.GetComponent<BoxCollider>().enabled = false;
                    //Bee.gameObject.GetComponent<SphereCollider>().enabled = false;
                    //Bee.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
    }
}