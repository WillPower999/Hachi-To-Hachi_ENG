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

        public Camera targetCamera;

        public SimpleCharacterController playerScript;

        public bool inkShotSelect = true;

        // Start is called before the first frame update
        void Start()
        {
            playerScript = Octo.GetComponent<SimpleCharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0f && inkShotSelect == true)
            {
                inkShotSelect = false;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") != 0f && inkShotSelect == false)
            {
                inkShotSelect = true;
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                if (movementMode == "Land" && playerScript.verticalSpeed == 0f)
                {
                    targetCamera.gameObject.GetComponent<OrbitingCamera>().target = beeTarget;
                    movementMode = "Sky";
                    Octo.GetComponent<SimpleCharacterController>().enabled = false;
                    Octo.GetComponent<HachiAnimator>().mover.isInWalkMode = false;
                    Bee.GetComponent<SkyMovement>().enabled = true;

                    beeBody.GetComponent<SphereCollider>().enabled = true;

                    Octo.GetComponent<Rigidbody>().isKinematic = true;
                    Octo.GetComponent<Rigidbody>().useGravity = true;
                }
                else if (movementMode == "Sky")
                {
                    targetCamera.gameObject.GetComponent<OrbitingCamera>().target = octoTarget;
                    movementMode = "Land";
                    Octo.GetComponent<SimpleCharacterController>().enabled = true;
                    Octo.GetComponent<HachiAnimator>().mover.isInWalkMode = true;
                    Bee.GetComponent<SkyMovement>().enabled = false;

                    beeBody.GetComponent<SphereCollider>().enabled = false;

                    inkShotSelect = true;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer == 4)
            {
                movementMode = "Sea";
                Octo.GetComponent<SimpleCharacterController>().enabled = false;
                Octo.GetComponent<SeaMovement>().enabled = true;

                Octo.GetComponent<Rigidbody>().isKinematic = false;
                Octo.GetComponent<Rigidbody>().useGravity = false;
                Octo.GetComponent<Rigidbody>().freezeRotation = true;
                Octo.GetComponent<Rigidbody>().drag = 3f;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == 4)
            {
                movementMode = "Land";
                Octo.GetComponent<SimpleCharacterController>().enabled = true;
                Octo.GetComponent<SeaMovement>().enabled = false;

                //Octo.transform.position = Octo.transform.position + new Vector3(0f, 2f, 0f);
            }
        }
    }
}