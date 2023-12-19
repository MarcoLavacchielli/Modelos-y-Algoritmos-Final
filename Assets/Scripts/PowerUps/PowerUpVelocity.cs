using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVelocity : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<GameObserver>().IncreaseSpeed(3f);
        Destroy(gameObject);
    }
}
