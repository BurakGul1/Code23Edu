using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private MeshRenderer _mesh;

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Duvara çarptı.");
        _mesh.material.color = Color.red;
    }
}
