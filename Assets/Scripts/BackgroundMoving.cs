using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public GameManager gameManager;  // Referință la GameManager pentru scor
    public int stopAtScore = 200;  // Scorul la care fundalul trebuie să fie complet vizibil

    private float startY;  // Poziția inițială a fundalului pe Y
    private float targetY;  // Poziția finală dorită a fundalului

    void Start()
    {
        startY = transform.position.y;  // Poziția inițială a fundalului

        // Obținem înălțimea fundalului (sprite-ului)
        float backgroundHeight = GetComponent<SpriteRenderer>().bounds.size.y;

        // Obținem înălțimea camerei (de la centru până sus x2)
        float cameraHeight = Camera.main.orthographicSize * 2f;

        // Poziția unde trebuie să ajungă fundalul, astfel încât marginea lui de sus să fie la marginea camerei
        targetY = startY - (backgroundHeight - cameraHeight) / 2f;
    }

    void Update()
    {
        // Dacă scorul a crescut, mișcă fundalul
        float progress = Mathf.Clamp01((float)gameManager.score / stopAtScore);

        // Calculăm noua poziție a fundalului
        float newY = Mathf.Lerp(startY, targetY, progress);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
