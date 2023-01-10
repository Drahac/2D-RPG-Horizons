using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    public static GameOverManager Instance;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
            return;
        }

        Instance = this;
    }

    public void OnPlayerDeath()
    {
        if (CurrentSceneManager.Instance.GetIsPlayerPresentByDefault())
        {
            DontDestroyOnLoadScene.Instance.RemoveFromDontDestroyOnLoad();
        }

        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        //Reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //spawn player
        PlayerHealth.Instance.Respawn();

        gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        DontDestroyOnLoadScene.Instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
