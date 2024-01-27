using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (other.gameObject.GetComponent<ClickAndDragWithDynamics>().generateInIteractableAreas)
            {
                Instantiate(other.gameObject.GetComponent<ClickAndDragWithDynamics>().generateInIteractableAreas, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
