using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float smoothness = 1f;
    private float yPositionTop = 1f;
    private float yPositionBottom = 0.1f;
    private bool doorOpen;
    private Plunger _plunger;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
        _plunger = FindObjectOfType<Plunger>();
    }

    void Update()
    {
        // Eğer listede top varsa, kapının y konumunu yPositionTop'a doğru yumuşak bir şekilde güncelle
        if (_plunger.ballList.Count > 0 && !doorOpen)
        {
            targetPosition.y = yPositionTop;
            doorOpen = true;
        }
        // Eğer listede top yoksa, kapının y konumunu yPositionBottom'a doğru yumuşak bir şekilde güncelle
        else if (_plunger.ballList.Count == 0 && doorOpen)
        {
            targetPosition.y = yPositionBottom;
            doorOpen = false;
        }

        // Yumuşak geçiş için Lerp fonksiyonunu kullanarak kapının y konumunu güncelle
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
    }
}