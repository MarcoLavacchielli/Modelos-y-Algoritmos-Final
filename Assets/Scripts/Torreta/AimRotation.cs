using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();

        if (playerController != null)
        {
            target = playerController.transform.Find("AimSpot");
        }
        else
        {
            Debug.LogError("Falla al encontrar");
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 targetOrientation = target.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.red);

        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, Time.deltaTime);

        // transform.rotation = Quaternion.LookRotation(targetOrientation);
    }
}