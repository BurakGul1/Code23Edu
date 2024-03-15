using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Vector3 _force;
    private void OnEnable()
    {
        Debug.Log("Enable Çalıştı");
    }

    private void OnDisable()
    {
        Debug.Log("Disable Çalıştı");
    }

    private void OnDestroy()
    {
        Debug.Log("Destroy Çalıştı");
    }

    private void Awake()
    {
        Debug.Log("Awake Çalıştı");
    }

    void Start()
    {
        Debug.Log("Start Çalıştı");
    }

    private void Update()
    {
        Debug.Log("Update Çalıştı");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(_force);
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate Çalıştı");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate Çalıştı");
    }
}
