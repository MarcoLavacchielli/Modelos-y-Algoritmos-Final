using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVelocity : MonoBehaviour
{
    [SerializeField] private ParticleSystem powerVelocityPs;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<GameObserver>().IncreaseSpeed(3f);
        powerVelocityPs.Play();
        Destroy(gameObject);
    }
}
