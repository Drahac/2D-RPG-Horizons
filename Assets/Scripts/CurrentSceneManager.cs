using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    private int startSceneHealth;
    [SerializeField] private int LevelToUnlock;

    public Vector3 respawnPoint;

    public static CurrentSceneManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scène");
            return;
        }

        Instance = this;

        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void Start()
    {
        startSceneHealth = PlayerHealth.Instance.GetHealth();
    }

    public int GetStartSceneHealth()
    {
        return startSceneHealth;
    }

    public int GetLevelToUnlock()
    {
        return LevelToUnlock;
    }
}
