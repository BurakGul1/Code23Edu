using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    private int _score;
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Hit"))
        {
            _score++;
            Debug.Log(_score + "tane çarpma gerçekleşti");
        }
    }
    
}
