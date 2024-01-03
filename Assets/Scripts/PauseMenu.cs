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
            Time.timeScale = 0f;
            pauseCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseCanvas.SetActive(false);
        }
    }

    public void Loadscene(string scenename)
    {
        Time.timeScale = 1f;
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
