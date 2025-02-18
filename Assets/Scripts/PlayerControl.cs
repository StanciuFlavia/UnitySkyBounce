using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float movementSpeed = 10f; // Viteza de mișcare
    float movement = 0f;
    private Rigidbody2D rb;

    private GameManager gameManager; // Referință la GameManager
    private float maxHeight = 0f;   // Înălțimea maximă atinsă de player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Găsește GameManager-ul în scenă
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;

        // Verifică dacă player-ul a urcat mai sus decât înălțimea maximă
        if (transform.position.y > maxHeight)
        {
            maxHeight = transform.position.y;
            gameManager.AddScore(1);
        }

        // Verifică dacă player-ul a căzut sub limita inferioară
        if (transform.position.y < GetBottomScreenY())
        {
            Debug.Log("Player a căzut! Y: " + transform.position.y);  // Adaugă log pentru debugging
            gameManager.GameOver();
        }
        UpdateG();
    }


    void FixedUpdate()
    {
        // Aplică mișcarea pe orizontală
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
    void UpdateG()
    {
        // Verificăm dacă player-ul cade sub limita inferioară
        if (transform.position.y < GetBottomScreenY())
        {
            // Anunță GameManager că jocul s-a terminat
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    float GetBottomScreenY()
    {
        // Returnează coordonata Y a marginii de jos a ecranului
        return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    }

}
