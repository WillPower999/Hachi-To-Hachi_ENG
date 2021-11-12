using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FujinguScript : MonoBehaviour
{
    /*[SerializeField] public Transform target;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float rotationalDamp = 0.5f;


    [SerializeField] float detectionDistance = 20f;
    [SerializeField] float rayCastOffset = 0.3f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        Pathfinding();
        //Turn();
        Move();

    }

    void Turn()

    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void Move()

    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    void Pathfinding()

    {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;

        Vector3 left = transform.position - transform.right * rayCastOffset;
        Vector3 right = transform.position + transform.right * rayCastOffset;
        Vector3 up = transform.position + transform.up * rayCastOffset;
        Vector3 down = transform.position - transform.up * rayCastOffset;

        Debug.DrawRay(left, transform.forward * detectionDistance, Color.red);
        Debug.DrawRay(right, transform.forward * detectionDistance, Color.red);
        Debug.DrawRay(up, transform.forward * detectionDistance, Color.red);
        Debug.DrawRay(down, transform.forward * detectionDistance, Color.red);

        if (Physics.Raycast(left, transform.forward, out hit, detectionDistance))

        {
            raycastOffset += Vector3.right;
        }

        else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance))

        {
            raycastOffset -= Vector3.right;
        }

        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance))

        {
            raycastOffset -= Vector3.up;
        }

        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance))

        {
            raycastOffset += Vector3.up;
        }

        if (raycastOffset != Vector3.zero)

        {
            transform.Rotate(raycastOffset * 5f * Time.deltaTime);
        }

        else

        {
            Turn();
        }



    }

}*/
    private float lookRadius = 60f;
    public bool timeToHit = true;
    public bool attacking = true;
    private float speed = 15f;

    public Transform target;
    NavMeshAgent agent;

    public GameObject hitbox;

    // Start is called before the first frame update
    void Start()
    {
        //target = PlayerManager.instance.player.transform;
        //agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        Vector3 dir = ((target.position + new Vector3(0f, 1f, 0f)) - transform.position).normalized;

        if (attacking)
        {
            if (distance <= lookRadius && distance > 3f)
            {
                //agent.SetDestination(target.position);
                FaceTarget();
                gameObject.GetComponent<Rigidbody>().velocity = (dir * speed);
            }
            else if (distance <= 3f && timeToHit)
            {
                FaceTarget();
                gameObject.GetComponent<Rigidbody>().velocity = (dir * speed/3);
                if (timeToHit)
                {
                    timeToHit = false;
                    StartCoroutine(hitTime());
                }
            }
        }
        else
        {
            FaceTarget();
            gameObject.GetComponent<Rigidbody>().velocity = ((-dir * speed/2) + new Vector3(0f, 1f, 0f));
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

    IEnumerator hitTime()
    {
        yield return new WaitForSeconds(0.5f);
        hitbox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hitbox.SetActive(false);
        attacking = false;
        yield return new WaitForSeconds(3f);
        timeToHit = true;
        attacking = true;
    }
}
