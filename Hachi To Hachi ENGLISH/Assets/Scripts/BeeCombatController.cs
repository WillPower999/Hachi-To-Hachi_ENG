using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenteBacata.ScivoloCharacterControllerDemo
{
    public class BeeCombatController : MonoBehaviour
    {
        public GameObject honeyDrop;
        public GameObject movement;
        public float velocity = 20f;

        public GameObject meleeBox;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            string mode = movement.GetComponent<MovementManager>().movementMode;

            if (Input.GetMouseButtonDown(1) && mode != "Sea")
            {
                GameObject projectile = Instantiate(honeyDrop, transform.position + new Vector3(0f, .5f, 0f),
                                                          transform.rotation);
                projectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * velocity);
            }

            if (Input.GetMouseButtonDown(0) && mode == "Sky")
            {
                StartCoroutine(hitTime());
            }
        }

        IEnumerator hitTime()
        {
            meleeBox.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            meleeBox.SetActive(false);
        }
    }
}