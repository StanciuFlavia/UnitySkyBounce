using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager; // Referință la GameManager
    public GameObject levelCompleteMenu;
    public GameObject gameOverMenu;

    public int requiredCoins;
    public int requiredScore;

    void Start()
    {
        levelCompleteMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    void Update()
    {
        // Verifică dacă jocul este în progres și că gameManager nu este null
        if (gameManager != null)
        {
            // Verifică dacă numărul de monede și scorul sunt în limitele dorite
            if (gameManager.coinCount >= requiredCoins && gameManager.score <= requiredScore)
            {
                LevelComplete();
            }
            // Verifică dacă nu s-au atins condițiile pentru completarea nivelului
            else if (gameManager.coinCount < requiredCoins && gameManager.score > requiredScore)
            {
                GameOver();
            }
        }
    }


    void LevelComplete()
    {
        levelCompleteMenu.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Nivel completat!");
    }

    public void NextLevel()
    {
        // Resetează scorul și monedele pentru nivelul următor
        gameManager.coinCount = 0;
        gameManager.score = 0;

        levelCompleteMenu.SetActive(false);
        Time.timeScale = 1f;

        // Încarcă următorul nivel (sau reîncarcă scena actuală pentru testare)
        Debug.Log("Trecere la următorul nivel...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
