using UnityEngine;
using System.Collections;

public class ClickAndDragWithDynamics : MonoBehaviour
{
    public Rigidbody2D selectedObject;
    public GameObject generateInIteractableAreas;
    Vector3 offset;
    Vector3 mousePosition;
    public float maxSpeed=10;
    Vector2 mouseForce;
    Vector3 lastPosition;
    public bool draggable = true;
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (selectedObject)
        {
            mouseForce = (mousePosition - lastPosition) / Time.deltaTime;
            mouseForce = Vector2.ClampMagnitude(mouseForce, maxSpeed);
            lastPosition = mousePosition;
        }
        if (Input.GetMouseButtonDown(0) && draggable)
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject.GetComponent<Rigidbody2D>();
                if (selectedObject == gameObject.GetComponent<Rigidbody2D>()){
                    offset = selectedObject.transform.position - mousePosition;
                    gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            if (selectedObject == gameObject.GetComponent<Rigidbody2D>()){
                selectedObject.velocity = Vector2.zero;
                //selectedObject.AddForce(mouseForce, ForceMode2D.Impulse);
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                    
            }
            selectedObject = null;
            
        }
    }
    void FixedUpdate()
    {
        if (selectedObject)
        {
            if (selectedObject == gameObject.GetComponent<Rigidbody2D>())
            {
                selectedObject.MovePosition(mousePosition + offset);
            }
            
        }
    }
}