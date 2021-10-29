using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NiriktenScript : MonoBehaviour
{
    public float lookRadius = 40f;
    public bool timeToHit = true;

    public Transform target;
    NavMeshAgent agent;

    public GameObject fireball;


    // Start is called before the first frame update
    void Start()
    {
        //target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            FaceTarget();

            if (distance <= agent.stoppingDistance)
            {
                //FaceTarget();
                if (timeToHit)
                {
                    timeToHit = false;
                    StartCoroutine(shoot());
                }
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    IEnumerator shoot()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject projectile = Instantiate(fireball, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
        projectile.GetComponent<Rigidbody>().velocity = (target.transform.position - transform.position).normalized * 20f;
        //projectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 20f);
        yield return new WaitForSeconds(1f);
        timeToHit = true;
    }
}