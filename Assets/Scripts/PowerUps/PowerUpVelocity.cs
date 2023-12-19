using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVelocity : MonoBehaviour
{
    [SerializeField] private GameObserver gameObserver;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObserver.IncreaseSpeed(3f);
            Destroy(gameObject);
        }
    }
}
