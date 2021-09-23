using System.Collections;
using MenteBacata.ScivoloCharacterController;
using System.Collections.Generic;
using UnityEngine;

namespace MenteBacata.ScivoloCharacterControllerDemo
{
    public class SeaMovement : MonoBehaviour
    {
        public float moveSpeed = 8f;

        public float x;
        public float z;

        public GameObject Octo;

        private Transform cameraTransform;

        // Start is called before the first frame update
        void Start()
        {
            cameraTransform = Camera.main.transform;
        }

        // Update is called once per frame
        void Update()
        {

            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            Vector3 forward = cameraTransform.forward;
            //Vector3.ProjectOnPlane(cameraTransform.forward, transform.up).normalized;
            Vector3 right = Vector3.Cross(transform.up, forward);

            Vector3 move = right * x + forward * z;
            Octo.GetComponent<Rigidbody>().AddForce(move * moveSpeed);

            RotateTowards(cameraTransform.forward);
        }

        private void RotateTowards(Vector3 direction)
        {
            Vector3 faceDirection = Vector3.ProjectOnPlane(direction, transform.up);

            if (faceDirection.sqrMagnitude < 1E-06f)
                return;

            Quaternion finalRotation = Quaternion.LookRotation(faceDirection, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, finalRotation, 720f * Time.deltaTime);
        }
    }
}