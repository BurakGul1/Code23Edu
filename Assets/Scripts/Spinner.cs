using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
   [SerializeField] private float xAngle;
   [SerializeField] private float yAngle;
   [SerializeField] private float zAngle;

   private void Update()
   {
      transform.Rotate(xAngle, yAngle, zAngle);
   }
}
