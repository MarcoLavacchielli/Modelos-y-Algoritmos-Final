using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailZone : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent("PlayerController"))
        {
            playerHp.failed = true;
        }
    }
}
