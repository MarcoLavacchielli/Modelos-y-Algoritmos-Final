using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualRotation : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        // Busco al player
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            // Encuentra el objeto
            target = player.transform.Find("AimSpot");
        }
        else
        {
            Debug.LogError("Falla al encontrar");
        }
    }

    void Update()
    {
        Vector3 targetOrientation = target.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.red);

        Quaternion targetRotation = Quaternion.LookRotation(targetOrientation);

        // Limitar la rotación en el eje Y (inclinación)
        targetRotation.eulerAngles = new Vector3(0f, targetRotation.eulerAngles.y, 0f);

        transform.rotation = targetRotation;
    }
}
