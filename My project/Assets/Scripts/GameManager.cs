using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timeLimit = 60f;

    public TextMeshProUGUI timerText;

    public GameObject retryPanel;

    private bool gameOver;

    public bool IsGameOver => gameOver;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        retryPanel.SetActive(false);
    }

    void Update()
    {
        if (gameOver) return;

        timeLimit -= Time.deltaTime;

        timerText.text =
            "Time : " + Mathf.CeilToInt(timeLimit);

        if (timeLimit <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;

        retryPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}