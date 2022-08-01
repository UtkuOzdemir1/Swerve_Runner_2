using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBouncer : MonoBehaviour
{
    [Range(100, 1000)]
    public float bounceHeight;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * bounceHeight);
    }
}
