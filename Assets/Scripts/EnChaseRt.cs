using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnChaseRt : MonoBehaviour
{
    [SerializeField] private Transform _target;

    void Update()
    {
        Vector3 targetOrientation = _target.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.red);

        Quaternion targetRotation = Quaternion.LookRotation(targetOrientation);

        // Limitar la rotación solo al eje Y (inclinación)
        transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
    }
}
