using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float distance = 5.0f;
    [SerializeField] private float angle = 30.0f;

    // Nueva variable pública para controlar la posición Y de la cámara
    [SerializeField] private float yOffset = 0.0f;

    private void Update()
    {
        if (playerTransform == null)
        {
            Debug.Log("Player reference missing");
            return;
        }

        // Almacena la rotación actual de la cámara
        Quaternion originalRotation = transform.rotation;

        // Aplica la nueva variable yOffset solo a la posición Y de la cámara
        Vector3 offset = Quaternion.Euler(angle, 0, 0) * Vector3.back * distance;
        offset.y += yOffset; // Agrega la yOffset solo a la posición Y
        transform.position = playerTransform.position + offset;

        // Restaura la rotación original de la cámara
        transform.rotation = originalRotation;
    }
}