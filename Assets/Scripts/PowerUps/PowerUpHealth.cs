using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerHealth>().Health(1);
        Destroy(gameObject);
    }
}
