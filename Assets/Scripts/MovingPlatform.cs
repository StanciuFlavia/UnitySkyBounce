using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f; // Viteza platformei
    public float moveDistance = 3f; // Distanța pe care platforma o parcurge

    private Vector3 startPosition;
    private int direction = 1; // Direcția de mișcare (1 = dreapta, -1 = stânga)

    public float jumpForce = 10f; // Forța săriturii

    void Start()
    {
        startPosition = transform.position; // Salvează poziția inițială
    }

    void Update()
    {
        // Mișcarea stânga-dreapta
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        // Inversăm direcția când platforma atinge limitele
        if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
        {
            direction *= -1; // Inversează direcția
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificăm dacă player-ul sare pe platformă
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Aplicăm forța de săritură
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
}
