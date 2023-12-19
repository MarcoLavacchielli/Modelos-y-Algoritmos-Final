using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealth : MonoBehaviour
{

    [SerializeField] private PlayerHealth playerHp;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHp.Health(1);
            Destroy(gameObject);
        }
    }
}
