using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables Instance { get; private set; }

    // Example of a global variable
    public string lastSceneName;

    private void Awake()
    {
        Debug.Log("init gloabl singleton");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevents the GameObject from being destroyed when changing scenes.
        }
        else
        {
            Destroy(gameObject); // Ensures that there's only one instance of this GameObject.
        }
    }
    
}
