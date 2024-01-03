using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 5;
    public event Action<float> OnHealthChange;

    [SerializeField] private GameObject loseCanvas;

    public float CurrentHealth
    {
        get { return currentHealth; }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        NotifyObservers();
    }

    public void Health(int healthAmout)
    {
        currentHealth += healthAmout;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        NotifyObservers();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Respawn();
            NotifyObservers();
        }

        NotifyObservers();
    }

    private void Respawn()
    {
        loseCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    private void NotifyObservers()
    {
        OnHealthChange?.Invoke(currentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            int damageAmount = enemy.damage;

            TakeDamage(damageAmount);
        }
    }
}
