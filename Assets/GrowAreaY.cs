using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAreaY : MonoBehaviour
{
    public float growthAmount = 0.1f; // La quantità totale di crescita
    public float growthDuration = 5.0f; // Durata della crescita in secondi

    private bool isGrowing = false; // Flag per controllare se l'oggetto sta già crescendo


    void Start()
    {
        StartCoroutine(GrowOverTime(growthDuration));
    }


    IEnumerator GrowOverTime(float duration)
    {
        Debug.Log("GrowOverTime");
        isGrowing = true;
        Transform otherTransform = transform;
        Vector3 originalScale = otherTransform.localScale; // Salva la scala originale
        Vector3 targetScale = originalScale + new Vector3(growthAmount, growthAmount, 0); // Calcola la scala target

        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            otherTransform.localScale = Vector3.Lerp(originalScale, targetScale, t); // Lerp linearmente tra la scala originale e quella target
            yield return null;
        }

        otherTransform.localScale = targetScale; // Assicurati che la scala finale sia esattamente quella target
        isGrowing = false;
    }

}
