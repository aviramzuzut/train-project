using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAgent : MonoBehaviour
{
    public bool isOnTrain;
    public bool shouldMove = false;
    public GameObject target;
    public GameObject train;
    private Rigidbody rb;

    void Start()
    {
        target = train;
        rb = gameObject.GetComponent<Rigidbody>(); // Add the rigidbody.
        rb.isKinematic = true;
    }

    void FixedUpdate()
    {
        var distance = Vector3.Distance(rb.position, target.transform.position);

        if (distance > 0f && shouldMove)
        {

            Vector3 movePosition = transform.position;
            transform.LookAt(target.transform);
            movePosition.x = Mathf.MoveTowards(rb.position.x, target.transform.position.x, 2f * Time.fixedDeltaTime);
            movePosition.y = Mathf.MoveTowards(rb.position.y, target.transform.position.y, 2f * Time.fixedDeltaTime);
            movePosition.z = Mathf.MoveTowards(rb.position.z, target.transform.position.z, 2f * Time.fixedDeltaTime);

            rb.MovePosition(movePosition);
        }
        else
        {
            shouldMove = false;
        }
    }
}
