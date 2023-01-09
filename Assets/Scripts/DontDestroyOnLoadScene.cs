using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    
    [SerializeField] private GameObject[] objects;

    public static DontDestroyOnLoadScene Instance;


    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DontDestroyOnLoadScene dans la scène");
            return;
        }

        Instance = this;


        foreach (var obj in objects)
        {
            DontDestroyOnLoad(obj);
        }
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var obj in objects)
        {
            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());
        }
    }

}
