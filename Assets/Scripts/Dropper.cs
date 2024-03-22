using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private float _needTime;
    void Update()
    {
        if (Time.time > _needTime)
        {
            Debug.Log("3 saniye geçti");
        }
    }
}
