using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractFunction : MonoBehaviour
{
    public float distanceToSee;
    public RaycastHit whatIHit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.blue);

        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
        {
            if (Input.GetKeyDown(KeyCode.E) && Cursor.lockState == CursorLockMode.Locked)
            {
                if (whatIHit.collider.tag == "Interactable")
                {
                    Debug.Log("Touchie " + whatIHit.collider.gameObject.name);
                    GameObject thingIUse = GameObject.Find(whatIHit.collider.gameObject.name);
                    if (thingIUse.GetComponent<DialogueTrigger>())
                    {
                        thingIUse.GetComponent<DialogueTrigger>().TriggerDialogue();
                        Debug.Log("talky");
                    }
                    switch (thingIUse.name)
                    {
                        default:
                            break;
                    }
                }
            }
        }
    }
}