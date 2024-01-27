using UnityEngine;
using System.Collections;
public class VerticalDoor : MonoBehaviour
{
    public Rigidbody2D selectedObject;
    Vector3 offset;
    Vector3 mousePosition;
    public float maxSpeed = 10;
    Vector2 mouseForce;
    Vector3 lastPosition;

    public float moveDistance = 1.0f; // Distanza di quanto l'oggetto si sposta verticalmente
    public float moveSpeed = 5.0f; // Velocità dello spostamento
    public float returnDelay = 2.0f; // Tempo prefissato prima che l'oggetto ritorni alla posizione originaria


    private Vector3 startPosition; // Posizione iniziale dell'oggetto
    
    private Vector3 targetPosition; // Posizione target dove l'oggetto deve spostarsi
    private bool isMoving = false; // Flag per controllare se l'oggetto si sta muovendo

    public bool selfClosing = true;

    private bool isOpen = false;

    private bool isReturning = false; // Flag per controllare se l'oggetto sta ritornando


    void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject.GetComponent<Rigidbody2D>();
                if (selectedObject == this.GetComponent<Rigidbody2D>()  && !isOpen)
                {
                    targetPosition = transform.position + new Vector3(0, moveDistance, 0);
                    isMoving = true;
                    isOpen = true;
                }
            }

        }

        if (isMoving)
        {
            MoveObject(targetPosition);
        }

        if (isReturning)
        {
            MoveObject(startPosition);
        }

    }

    void MoveObject(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, moveSpeed * Time.deltaTime);

        // Se l'oggetto ha raggiunto la posizione target o la posizione iniziale
        if (transform.position == position)
        {
            if (isMoving)
            {
                isMoving = false;
                StartCoroutine(ReturnAfterDelay());
            }
            else if (isReturning)
            {
                isReturning = false;
                isOpen = false;
            }
        }
    }

    // Coroutine per ritardare il ritorno dell'oggetto alla posizione iniziale
    IEnumerator ReturnAfterDelay()
    {
        if (selfClosing) {
            yield return new WaitForSeconds(returnDelay);
            isReturning = true;
        }
    }



}