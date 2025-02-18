using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // Valoarea monedei

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verificăm dacă player-ul a atins moneda
        {
            // Adaugă monedele colectate în GameManager
            FindObjectOfType<GameManager>().AddCoin(coinValue);


            // Distruge moneda după ce a fost colectată
            Destroy(gameObject);
        }
    }
}

