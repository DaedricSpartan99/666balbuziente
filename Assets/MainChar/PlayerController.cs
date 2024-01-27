using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private KeyCode[] keySequence = new KeyCode[] { KeyCode.A, KeyCode.S, KeyCode.D };
    private KeyCode[] keySequenceJump = new KeyCode[] { KeyCode.N, KeyCode.J, KeyCode.I };
    private int currentIndex = 0; // Indice corrente nella sequenza di tasti
    private int currentIndexJump = 0; // Indice corrente nella sequenza di tasti

    public float allowedTimeBetweenKeys = 2f; // Tempo massimo tra un tasto e l'altro
    private float timeLastKeyWasPressed;
    private float timeLastKeyWasPressedJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        
        Galoppo();

        // Handle player jumping
        if (isGrounded)
        {
            Salto();
        }
    }

    void Salto()
    {
        // Verifica se il tasto corrente della sequenza è stato premuto
        if (Input.GetKeyDown(keySequenceJump[currentIndexJump]))
        {
            // Verifica se è il primo tasto della sequenza o se il tasto è stato premuto in tempo
            if (Time.time - timeLastKeyWasPressedJump < allowedTimeBetweenKeys || currentIndexJump == 0)
            {
                currentIndexJump++; // Passa al prossimo tasto della sequenza
                timeLastKeyWasPressedJump = Time.time; // Aggiorna l'ultima volta che è stato premuto un tasto

                // Se tutti i tasti sono stati premuti in sequenza
                if (currentIndexJump >= keySequenceJump.Length)
                {
                    currentIndexJump = 0; // Resetta l'indice per la prossima sequenza
                    MoveCharacterJump(); // Chiama la funzione per muovere il personaggio
                }
            }
            else
            {
                // Se c'è stato un errore o un ritardo, resetta la sequenza
                currentIndexJump = 0; 
            }
        }
    }

    void MoveCharacterJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void Galoppo()
    {
        // Verifica se il tasto corrente della sequenza è stato premuto
        if (Input.GetKeyDown(keySequence[currentIndex]))
        {
            // Verifica se è il primo tasto della sequenza o se il tasto è stato premuto in tempo
            if (Time.time - timeLastKeyWasPressed < allowedTimeBetweenKeys || currentIndex == 0)
            {
                currentIndex++; // Passa al prossimo tasto della sequenza
                timeLastKeyWasPressed = Time.time; // Aggiorna l'ultima volta che è stato premuto un tasto
                // Se tutti i tasti sono stati premuti in sequenza
                if (currentIndex >= keySequence.Length)
                {
                    currentIndex = 0; // Resetta l'indice per la prossima sequenza
                    MoveCharacter(); // Chiama la funzione per muovere il personaggio
                }
            }
            else
            {
                // Se c'è stato un errore o un ritardo, resetta la sequenza
                currentIndex = 0; 
            }
        }
    }

    void MoveCharacter()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("KillerArea"))
        {
            Debug.Log("Morto");
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}



    