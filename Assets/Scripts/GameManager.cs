using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverMenu;

    public int score = 0;
    public int coinCount = 0;

    void Start()
    {
        Time.timeScale = 1f;
        UpdateScoreUI();
        if (gameOverMenu != null)
            gameOverMenu.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void AddCoin(int coinValue)
    {
        coinCount += coinValue;
        Debug.Log("Monede colectate: " + coinCount);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        if (gameOverMenu != null)
            gameOverMenu.SetActive(true);

        Time.timeScale = 0f;
        Debug.Log("Game Over!");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

