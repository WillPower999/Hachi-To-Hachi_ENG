using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int timeStep = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Clock());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<TestDummy>().health--;
            Destroy(this.gameObject);
        }
        else if (other.tag != "Player" && other.gameObject.layer != 4)
        {
            Destroy(this.gameObject);
        }
    }

    /*private void FixedUpdate()
    {
        if (timeStep < 30)
        {
            timeStep++;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }*/

    IEnumerator Clock()
    {
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }
}
