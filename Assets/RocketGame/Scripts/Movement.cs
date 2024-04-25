using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody _rb;
    private Quaternion _originalRotation;
    [SerializeField] private float _mainThrust = 1000f;
    [SerializeField] private float _rotationThrust = 60f; // Maksimum dönüş açısı

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _originalRotation = transform.rotation;

        // Rigidbody constraints ayarları
        _rb.constraints = RigidbodyConstraints.FreezePositionZ; // Z ekseni etkisiz hale getirildi
    }

    void Update()
    {
        ProcessInput();
        ProcessThrust();
    }
    
    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateThrust(_rotationThrust); // Sola döndür
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateThrust(-_rotationThrust); // Sağa döndür
        }
        else
        {
            // A ve D tuşlarına basılmadığında roketi orijinal konumuna döndür
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _originalRotation, _rotationThrust * Time.deltaTime);
        }
    }

    private void RotateThrust(float rotationAmount)
    {
        _rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationAmount * Time.deltaTime);
        _rb.freezeRotation = false;
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddRelativeForce(Vector3.up * _mainThrust * Time.deltaTime);
            Debug.Log("Pressed Space - Thrusting");            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Yere çarpınca roketi düzelt
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.up = Vector3.up; // Yere dik olarak hizala
        }
    }
}