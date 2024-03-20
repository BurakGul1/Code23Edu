using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _x;
    private float _z;
    [SerializeField] private float _speed = .2f;
   
    void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");
        transform.Translate(_x * _speed * Time.deltaTime, 0f, _z * _speed * Time.deltaTime);
    }
}
