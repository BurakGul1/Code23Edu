using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
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
        StartCoroutine(TestCoroutine());
    }

    IEnumerator TestCoroutine () {
        yield return new WaitForSeconds (3f);
        _mesh.material.color = Color.clear;
    }
}
