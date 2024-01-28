using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject endGamePlayer;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(endGamePlayer, transform.position, Quaternion.identity);
            this.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
    }
}
