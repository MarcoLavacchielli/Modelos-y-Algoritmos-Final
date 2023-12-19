using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float distance = 5.0f;
    [SerializeField] private float angle = 30.0f;

    // Nueva variable p�blica para controlar la posici�n Y de la c�mara
    [SerializeField] private float yOffset = 0.0f;

    private void Update()
    {
        if (playerTransform == null)
        {
            Debug.Log("Player reference missing");
            return;
        }

        // Almacena la rotaci�n actual de la c�mara
        Quaternion originalRotation = transform.rotation;

        // Aplica la nueva variable yOffset solo a la posici�n Y de la c�mara
        Vector3 offset = Quaternion.Euler(angle, 0, 0) * Vector3.back * distance;
        offset.y += yOffset; // Agrega la yOffset solo a la posici�n Y
        transform.position = playerTransform.position + offset;

        // Restaura la rotaci�n original de la c�mara
        transform.rotation = originalRotation;
    }
}