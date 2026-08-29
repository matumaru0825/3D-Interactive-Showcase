using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f;

    public TMP_Text timerText;
    public TMP_Text gameOverText;

    private float currentTime;
    private bool gameOver = false;

    void Start()
    {
        currentTime = timeLimit;

        gameOverText.gameObject.SetActive(false);

        UpdateTimerText();
    }

    void Update()
    {
        // ゲームオーバー中
        if (gameOver)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                RestartGame();
            }

            return;
        }

        // 時間を減らす
        currentTime -= Time.deltaTime;

        // 時間切れ
        if (currentTime <= 0)
        {
            currentTime = 0;
            gameOver = true;

            GameOver();
        }

        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        timerText.text = "TIME : " + Mathf.CeilToInt(currentTime);
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");

        gameOverText.gameObject.SetActive(true);

        Time.timeScale = 0f;
    }

    void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}