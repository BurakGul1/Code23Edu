using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _x;
    private float _z;
    [SerializeField] private float _speed = .2f;

    private void Start()
    {
        PrintInstruction();
    }

    void Update()
    {
       MovePlayer();
    }

    void PrintInstruction()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or arrow keys");
        Debug.Log("Don't hit the walls!");
    }

    void MovePlayer()
    {
        _x = Input.GetAxis("Horizontal") * Time.deltaTime;
        _z = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(_x * _speed, 0f, _z * _speed);
    }
}
