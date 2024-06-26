using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i +1 > levelReached) { 
                levelButtons[i].interactable = false;
            }
        }
    }
    public void LoadLevelPassed(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}
