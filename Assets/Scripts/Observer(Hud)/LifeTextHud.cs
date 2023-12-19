using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeTextHud : MonoBehaviour
{
    [SerializeField] private Text textoVida;
    [SerializeField] private float vidaMaxima = 5f;
    private float vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
        ActualizarInterfazVida();

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
        vidaActual = health;
        ActualizarInterfazVida();
    }

    public void ReducirVida(float cantidad)
    {
        vidaActual -= cantidad;
        ActualizarInterfazVida();
    }

    public void AumentarVida(float cantidad)
    {
        vidaActual += cantidad;
        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
        ActualizarInterfazVida();
    }

    private void ActualizarInterfazVida()
    {
        float porcentajeVida = vidaActual / vidaMaxima;
        textoVida.text = $"Hp: {vidaActual}/{vidaMaxima}";
    }
}