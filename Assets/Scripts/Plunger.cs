using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plunger : MonoBehaviour
{
    private float power;
    private float minPower = 0f;
    public float maxPower = 100f;
    public Slider powerSlider;
    public List<Rigidbody> ballList;
    private bool ballReady;

    void Start()
    {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();
    }

    void Update()
    {
        if (ballReady)
        {
            powerSlider.gameObject.SetActive(true);
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
        }
        powerSlider.value = power;
        if (ballList.Count > 0)
        {
            ballReady = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if (power <= maxPower)
                {
                    power += 50 * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                foreach (Rigidbody r in ballList)
                {
                    r.AddForce(power * Vector3.forward);
                }
                power = 0f; // Kuvvet uygulandıktan sonra gücü sıfırla
            }
        }
        else
        {
            ballReady = false;
            power = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
            powerSlider.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            if (ballList.Count == 0)
            {
                powerSlider.gameObject.SetActive(false);
            }
        }
    }
}