using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualRotation : MonoBehaviour
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

        Quaternion targetRotation = Quaternion.LookRotation(targetOrientation);

        targetRotation.eulerAngles = new Vector3(0f, targetRotation.eulerAngles.y, 0f);

        transform.rotation = targetRotation;
    }
}