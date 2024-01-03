using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass : MonoBehaviour
{

    [SerializeField] private string sceneToGo;

    [SerializeField] private GameObject victoryCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent("PlayerController"))
        {
            victoryCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void GoNext()
    {
        Time.timeScale = 1f;
        victoryCanvas.SetActive(false);
        SceneManager.LoadScene(sceneToGo);
    }
}
