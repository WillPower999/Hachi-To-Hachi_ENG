using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MenteBacata.ScivoloCharacterControllerDemo
{

    public class world_transport : MonoBehaviour
    {
        public int sceneToLoad;
        public GameObject player;
        public float loadTime;

        void OnTriggerEnter(Collider player)
        {
            player.gameObject.GetComponent<SimpleCharacterController>().enabled = false;
            player.gameObject.GetComponent<HachiAnimator>().mover.isInWalkMode = false;

            StartCoroutine(LoadTime());
        }

        private IEnumerator LoadTime()
        {
            player.gameObject.GetComponent<HachiAnimator>().enabled = false;
            yield return new WaitForSeconds(loadTime);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        }
    }
}