using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; // Prefab-ul platformei
    public float spawnInterval = 1.5f; // Intervalul între spawn-uri
    public float verticalSpacing = 1.5f; // Distanta dintre platforme
    private float currentHeight = 0f; // Înălțimea la care se află player-ul
    private float screenBottom; // Marginea inferioară a camerei

    void Start()
    {
        // Obținem marginea inferioară a camerei
        screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        // Inițiem spawn-ul platformelor
        InvokeRepeating(nameof(SpawnPlatform), 1f, spawnInterval);
    }

    void SpawnPlatform()
    {
        // Poziție aleatorie pe X
        float randomX = Random.Range(-2f, 2f);

        // Poziția de spawn va fi bazată pe înălțimea curentă
        Vector3 spawnPosition = new Vector3(randomX, currentHeight + screenBottom, 0f);

        // Instanțiem platforma
        GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        newPlatform.transform.localScale = Vector3.one;

        // Creștem înălțimea la care vor apărea platformele
        currentHeight += verticalSpacing;
    }
}
