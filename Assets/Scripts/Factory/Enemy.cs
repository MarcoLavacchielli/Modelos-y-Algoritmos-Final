using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public int damage = 1;
    public float speed = 1f;

    public void TakeDamage(int amount)
    {
        health -= amount;

        AudioManager.Instance.PlaySFX(0);

        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}