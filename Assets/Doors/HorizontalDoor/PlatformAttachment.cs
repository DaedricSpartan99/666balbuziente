using UnityEngine;

public class PlatformAttachment : MonoBehaviour
{
    private Transform playerTransform; // Riferimento al Transform del giocatore
    private Transform platformTransform; // Riferimento al Transform della piattaforma

    void Start()
    {
        Debug.Log("trovo il player");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Assicurati che il player abbia il tag "Player"
        platformTransform = transform; // Il transform di questo script è presumibilmente attaccato alla piattaforma
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("interagggggisco");
        // Controlla se il player è entrato nella piattaforma
        if (other.transform == playerTransform)
        {
            playerTransform.SetParent(platformTransform); // Imposta la piattaforma come parent del player
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Controlla se il player ha lasciato la piattaforma
        if (other.transform == playerTransform)
        {
            playerTransform.SetParent(null); // Rimuove la parentela
        }
    }
}
