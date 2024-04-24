using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    float ballPushForce = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 normal = collision.contacts[0].normal;
            rb.AddForce(-normal * ballPushForce); // Topa zıt yönde kuvvet uygula
        }
    }
}
