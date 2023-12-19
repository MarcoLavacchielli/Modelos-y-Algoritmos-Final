using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<GameObserver>().IncreaseDamage(1);
        Destroy(gameObject);
    }
}
