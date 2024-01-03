using UnityEngine;
using UnityEngine.UI;

public class LifeTextHud : MonoBehaviour
{
    [SerializeField] private Text textLife;
    [SerializeField] private float maxHealth = 5f;
    private float actualLife;

    void Start()
    {
        actualLife = maxHealth;
        UpdateInterfaceLife();

        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.OnHealthChange += OnHealthChanged;
        }
    }

    private void OnDestroy()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.OnHealthChange -= OnHealthChanged;
        }
    }

    public void OnHealthChanged(float health)
    {
        actualLife = health;
        UpdateInterfaceLife();
    }

    public void ReduceHealth(float cantidad)
    {
        actualLife -= cantidad;
        UpdateInterfaceLife();
    }

    public void IncreaseHealth(float cantidad)
    {
        actualLife += cantidad;
        if (actualLife > maxHealth)
        {
            actualLife = maxHealth;
        }
        UpdateInterfaceLife();
    }

    private void UpdateInterfaceLife()
    {
        float porcentajeVida = actualLife / maxHealth;
        textLife.text = $"Hp: {actualLife}/{maxHealth}";
    }
}