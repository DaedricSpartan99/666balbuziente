using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_male_talk : MonoBehaviour
{
    //public List<AudioClip> collisionSounds = new List<AudioClip>();

    public AudioClip[] collisionSounds;
    public float audioScale = 1.0f;
    public GameObject comic;
    public GameObject toFlip;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
      source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")) {
          source.PlayOneShot(collisionSounds[Random.Range(0, collisionSounds.Length)], audioScale);
        }

        if (comic) {
          comic.SetActive(true);
        }

        if (toFlip) {
          toFlip.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
