using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;      // El Canvas del menú de pausa
    public string feedbackSceneName;    // Nombre de la escena de retroalimentación

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitToFeedback()
    {
        Time.timeScale = 1f; // Asegúrate de restaurar el tiempo
        SceneManager.LoadScene(feedbackSceneName);
    }
}
