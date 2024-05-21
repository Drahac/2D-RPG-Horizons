using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused=false;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject settingsWindow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        MovePlayer.Instance.enabled = false;

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        MovePlayer.Instance.enabled = true;

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OpenSettings()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsWindow.SetActive(false);
    }

    public void MainMenu()
    {        
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
