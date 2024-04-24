using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Vector3 pos = new Vector3(3.109f, 0.13f,1.42f);
            Instantiate(ballPrefab, pos, Quaternion.identity);
        }
    }
}
