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

    //[SerializeField] private ParticleSystem damageP;


    //[SerializeField] private Checkpoint checkpoint;


    [SerializeField] private PlayerOriginator playerOriginator;
    //
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

        if (currentHealth > 5)
        {
            currentHealth = maxHealth;
        }

        NotifyObservers();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        //damageP.Play();
        //AudioManager.Instance.PlaySFX(6);

        /*if (currentHealth <= 0)
        {
            try
            {
                if (checkpoint != null && checkpoint.IsCheckpointActivated())
                {
                    // Reposicionar al jugador en el checkpoint y restablecer su vida
                    transform.position = checkpoint.GetCheckpointPosition();
                    currentHealth = maxHealth;
                    NotifyObservers();
                }
                else
                {
                    currentHealth = 0;
                    Respawn();
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning("Error handling checkpoint: " + e.Message);
            }
        }
        else
        {
            NotifyObservers();
        }*/

        if (currentHealth <= 0)
        {
            Respawn();
            NotifyObservers();
        }

        NotifyObservers();
    }

    private void Respawn()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reiniciar la escena
        //NotifyObservers();
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
            int damageAmount = 0;

            // Pregunta por el tipo específico de enemigo
            if (enemy is EnemyType1)
            {
                damageAmount = ((EnemyType1)enemy).damage;
                Debug.Log(damageAmount + " 1");
            }
            else if (enemy is EnemyType2)
            {
                damageAmount = ((EnemyType2)enemy).damage;
                Debug.Log(damageAmount + " 2");
            }
            else if (enemy is EnemyType3)
            {
                damageAmount = ((EnemyType3)enemy).damage;
                Debug.Log(damageAmount + " 3");
            }

            // Aplica el daño al jugador
            TakeDamage(damageAmount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            this.savedmemento = playerOriginator.Save();
        }
    }
}
