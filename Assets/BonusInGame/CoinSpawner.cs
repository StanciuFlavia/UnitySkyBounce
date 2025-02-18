using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Prefabul monedei
    public float spawnInterval = 2f; // Intervalul între spawn-uri (în secunde)
    public float spawnHeight = 10f; // Înălțimea la care se va spawn-a moneda

    private Transform player; // Referință la player

    void Start()
    {
        // Căutăm obiectul player-ului
        player = GameObject.FindWithTag("Player").transform;

        // Începem să spawn-ăm monedele la intervale
        InvokeRepeating("SpawnCoin", 0f, spawnInterval);
    }

    void SpawnCoin()
    {
        // Verificăm dacă jucătorul a ajuns la înălțimea necesară
        if (player.position.y > spawnHeight)
        {
            // Verificăm dacă coinPrefab este valid
            if (coinPrefab != null)
            {
                Debug.Log("Spawnăm o monedă...");
                // Creăm o monedă la o poziție aleatorie pe axa X, dar la o înălțime fixă
                Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), player.position.y + spawnHeight, 0f);

                // Instantiem moneda
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogError("Coin Prefab este null! Verifică referința în Inspector.");
            }
        }
    }
}