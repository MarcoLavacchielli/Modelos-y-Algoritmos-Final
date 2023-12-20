using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDamage : MonoBehaviour
{

    [SerializeField] private ParticleSystem powerDamagePs;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<GameObserver>().IncreaseDamage(1);
        powerDamagePs.Play();
        Destroy(gameObject);
    }
}
