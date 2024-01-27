using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Polotto : MonoBehaviour
{
    public GameObject myCacca;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cacca"))
        {
            GetComponent<Collider2D>().enabled = false;
            myCacca.SetActive(true);
        }
    }
}
