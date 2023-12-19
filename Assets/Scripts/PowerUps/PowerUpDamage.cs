using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDamage : MonoBehaviour
{
    [SerializeField] private GameObserver gameObserver;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Avisa al observador para aumentar el daño
            gameObserver.IncreaseDamage(1);

            // Destruye el power-up
            Destroy(gameObject);
        }
    }
}
