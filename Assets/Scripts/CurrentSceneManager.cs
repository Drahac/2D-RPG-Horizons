using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    [SerializeField] private bool isPlayerPresentByDefault;

    private int startSceneHealth;

    public static CurrentSceneManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scène");
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        startSceneHealth = PlayerHealth.Instance.GetHealth();
    }

    public bool GetIsPlayerPresentByDefault()
    {
        return isPlayerPresentByDefault;
    }

    public int GetStartSceneHealth()
    {
        return startSceneHealth;
    }
}
