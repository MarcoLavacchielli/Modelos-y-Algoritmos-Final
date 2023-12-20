using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausar el tiempo en el juego
            pauseCanvas.SetActive(true); // Mostrar el canvas de pausa
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el tiempo en el juego
            pauseCanvas.SetActive(false); // Ocultar el canvas de pausa
        }
    }

    public void loadscene(string scenename) //carga una escena especifica por nombre
    {
        Time.timeScale = 1f; // Reanudar el tiempo en el juego
        SceneManager.LoadScene(scenename);
    }

    public void ChangeToSp()
    {
        if (LocalizationManager.Instance != null)
        {
            LocalizationManager.Instance.SetLanguageAs("ES_LA");
        }
    }

    public void ChangeToEn()
    {
        if (LocalizationManager.Instance != null)
        {
            LocalizationManager.Instance.SetLanguageAs("EN_US");
        }
    }
}
