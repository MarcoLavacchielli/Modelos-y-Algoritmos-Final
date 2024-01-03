using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private LayerMask checkPoint;
    public event Action<float> OnHealthChange;

    [SerializeField] private PlayerOriginator playerOriginator;

    private PlayerOriginator.PlayerMemento savedmemento;

    public bool failed = false;

    [SerializeField] private GameObject loseCanvas;

    private void Awake()
    {
        this.savedmemento = playerOriginator.Save();
        //Debug.Log("buena salvada");
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        NotifyObservers();
    }

    private void Update()
    {
        if (failed == true)
        {
            playerOriginator.Restore(savedmemento);
            failed = false;
            TakeDamage(1);
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (checkPoint == (checkPoint | (1 << other.gameObject.layer)))
        {
            this.savedmemento = playerOriginator.Save();
        }
    }
}
