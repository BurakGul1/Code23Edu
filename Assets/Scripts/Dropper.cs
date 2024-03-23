using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private float _needTime;
    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidbody;
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer.enabled = false;
        _rigidbody.useGravity = false;
    }

    void Update()
    {
        if (Time.time > _needTime)
        {
            _meshRenderer.enabled = true;
            _rigidbody.useGravity = true;
        }
    }
}
