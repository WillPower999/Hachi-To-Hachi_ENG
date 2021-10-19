using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MenteBacata.ScivoloCharacterController;

namespace MenteBacata.ScivoloCharacterControllerDemo
{
    public class HachiAnimator : MonoBehaviour
    {
        public GameObject player;
        public Animator animator;
        public CharacterMover mover;
        public GroundDetector detector;
        public SeaMovement seaMovement;
        public SimpleCharacterController SimpleCharacterController;

        private void Update()
        {
            if (mover.isInWalkMode == true)
            {
                animator.SetBool("OnGround", true);
                animator.SetBool("InWater", false);
                animator.SetBool("InAir", false);
            }

            else if (mover.isInWalkMode == false)
            {
                animator.SetBool("OnGround", false);

                if (seaMovement.isActiveAndEnabled == true)
                {
                    animator.SetBool("InWater", true);
                }

                else if (seaMovement.isActiveAndEnabled == false)
                {
                    animator.SetBool("InAir", true);
                }
            }

            if (Input.GetAxis("Horizontal") != 0.0f)
            {
                animator.SetBool("Moving", true);
            }

            if (Input.GetAxis("Vertical") != 0.0f)
            {
                animator.SetBool("Moving", true);
            }

            if (Input.GetAxis("Horizontal") == 0.0f && Input.GetAxis("Vertical") == 0.0f)
            {
                animator.SetBool("Moving", false);
            }

            /*if (Input.GetAxis("Jump") == 1)
            {
                animator.SetTrigger("Jump");
                animator.ResetTrigger("Jump");
            }
            */
        }


    }
}
