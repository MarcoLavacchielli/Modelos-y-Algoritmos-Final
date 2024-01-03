using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCanvas : MonoBehaviour
{

    [SerializeField] private GameObject loseCanvas;

    public void TryAgain()
    {
        loseCanvas.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        loseCanvas.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LoadingMenu");
    }
}
