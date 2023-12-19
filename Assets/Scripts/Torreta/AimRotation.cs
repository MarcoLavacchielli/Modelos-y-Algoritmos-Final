using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    private Transform _target;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            _target = player.transform.Find("AimSpot");
        }
        else
        {
            Debug.LogError("Falla al encontrar");
        }
    }

    void Update()
    {
        Vector3 targetOrientation = _target.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.red);


        //slerp
        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, Time.deltaTime);

        transform.rotation = Quaternion.LookRotation(targetOrientation);

    }
}
