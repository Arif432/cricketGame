using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    private SphereCollider field;
    private Rigidbody rb;
    private Vector3 originalPosition;
    public float returnSpeed = 1f;
    public float runSpeed = 0.5f;


    private void Start()
    {
        field = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            rb.position = Vector3.MoveTowards(transform.position, other.transform.position, runSpeed* Time.deltaTime);
        }
    }

    public void OnTriggerExit(Collider other)
    {
            StartCoroutine(ReturnToOriginalPosition());
    }

    private IEnumerator ReturnToOriginalPosition()
    {
        while (transform.position != originalPosition)
        {
            // time*delta smooths out the movement so it's the same speed on all computers.
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, returnSpeed * Time.deltaTime);
            //  wait until the next frame before continuing the loop.
            yield return null;
        }
    }
}
