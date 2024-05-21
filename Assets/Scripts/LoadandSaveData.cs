using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadandSaveData : MonoBehaviour
{

    public static LoadandSaveData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de load & save dans la scene");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        Inventory.Instance.SetCoinsCount(PlayerPrefs.GetInt("CoinsCount", 0));
        Inventory.Instance.UpdateTextUI();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("CoinsCount", Inventory.Instance.GetCoinsCount());

        int nextLevel = CurrentSceneManager.Instance.GetLevelToUnlock();
        if (nextLevel > PlayerPrefs.GetInt("LevelReached", 1)) {
            PlayerPrefs.SetInt("LevelReached", CurrentSceneManager.Instance.GetLevelToUnlock());
        }
    }


}
