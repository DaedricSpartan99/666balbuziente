using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Assicurati di includere questo namespace per lavorare con scene


public class RespownerScript : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collido!");
        // Controlla se il GameObject che entra nel trigger ha il tag "Player"
        if (other.CompareTag("Player"))
        {
            // Ricomincia il livello corrente
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
