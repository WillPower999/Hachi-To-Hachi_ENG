using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
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
        if (other.tag == "Player" && HealthBarV2.Instance != null)
        {
            //GlobalGameState.currentGame.health--;
            print("hurt");
            //FindObjectOfType<PlayerHealth>().TakeDamage(1);
            Destroy(this.gameObject);
            HealthBarV2.Instance.DeductHealth();
        }
        else if (other.tag != "Enemy" && other.gameObject.layer != 4)
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
        yield return new WaitForSeconds(8);
        Destroy(this.gameObject);
    }
}
