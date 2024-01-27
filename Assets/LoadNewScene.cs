using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnCollision : MonoBehaviour
{
    public string sceneNameToLoad; // The name of the scene you want to load

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player (or whatever object you're interested in)
        if (other.CompareTag("Player")) // Make sure your player GameObject has the tag "Player"
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Load the scene with the specified name
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
