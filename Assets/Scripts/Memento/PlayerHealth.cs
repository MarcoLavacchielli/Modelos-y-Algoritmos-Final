using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int currentHealth;
    [SerializeField] private int maxHealth = 5;
    //public event Action<float> OnHealthChange;

    //[SerializeField] private ParticleSystem damageP;


    //[SerializeField] private Checkpoint checkpoint;


    [SerializeField] private PlayerOriginator playerOriginator;
    //
    private PlayerOriginator.PlayerMemento savedmemento;

    private void Awake()
    {
        this.savedmemento = playerOriginator.Save();
        //Debug.Log("buena salvada");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(7);
        }
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        //NotifyObservers();
    }

    /*private void Update()
    {
        if (maxHealth > 5)
        {
            maxHealth = 5;
        }
    }*/

    public void Health(int healthAmout)
    {
        currentHealth += healthAmout;

        if (currentHealth > 5)
        {
            currentHealth = 5;
        }

        //NotifyObservers();
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
        }
    }

    private void Respawn()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reiniciar la escena
        playerOriginator.Restore(savedmemento);
        Debug.Log("Memento restored"); 
        currentHealth = maxHealth;
        //NotifyObservers();
        //Debug.Log("cargado");
    }

    /*private void NotifyObservers()
    {
        OnHealthChange?.Invoke(currentHealth);
    }*/

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            float damageAmount = 1f;
            TakeDamage(damageAmount);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            this.savedmemento = playerOriginator.Save();
        }
    }
}
