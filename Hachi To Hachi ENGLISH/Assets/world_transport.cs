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
        public GameObject setPosition;
        public destinationPortal portalSpawning;

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
            DontDestroyOnLoad(gameObject.transform.parent.gameObject);
            yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneToLoad);
            world_transport returnPortal = GameObject.FindObjectOfType<world_transport>();
            Debug.Log("[world_transport.cs/LoadTime()] Return Portal Spawn" + returnPortal.setPosition.transform.position);
            GameObject.FindObjectOfType<SimpleCharacterController>().transform.position = new Vector3(returnPortal.setPosition.transform.position.x + 2, returnPortal.setPosition.transform.position.y + 0.25f, returnPortal.setPosition.transform.position.z - 4);
            GameObject.FindObjectOfType<BeeCombatController>().transform.position = returnPortal.setPosition.transform.position;
            Debug.Log("[world_transport.cs/LoadTime()] Octchi Spawn " + GameObject.FindObjectOfType<SimpleCharacterController>().transform.position);
            Debug.Log("[world_transport.cs/LoadTime()] Hachbee Spawn " + GameObject.FindObjectOfType<BeeCombatController>().transform.position);
            Destroy(gameObject.transform.parent.gameObject);
            //player.transform.position = setPosition.transform.position;
        } 
    }

    public enum destinationPortal
    {
        toL1,
        //toL2,
        toHub
    }
}