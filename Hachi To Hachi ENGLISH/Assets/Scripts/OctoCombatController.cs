using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoCombatController : MonoBehaviour
{
    public GameObject inkShot;
    public float velocity = 20f;

    public GameObject meleeBox;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject projectile = Instantiate(inkShot, transform.position + new Vector3(0f,1f,0f),
                                                      transform.rotation);
            projectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * velocity);
        }

        if (Input.GetMouseButtonDown(0))
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