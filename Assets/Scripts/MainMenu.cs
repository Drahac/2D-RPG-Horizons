using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //private string levelToLoad="Level01";

    [SerializeField] private GameObject settingWindow;
    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Settings()
    {
        settingWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadCredit()
    {
        SceneManager.LoadScene("Credits");
    }
}
