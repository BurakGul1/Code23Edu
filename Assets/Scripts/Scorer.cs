using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    private int _score;
    private void OnCollisionEnter(Collision other)
    {
        _score++;
        Debug.Log(_score + "tane çarpma gerçekleşti");
    }
    
}
