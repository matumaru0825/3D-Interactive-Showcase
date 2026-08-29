using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    public TMP_Text scoreText;

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore()
    {
        score++;

        UpdateScoreText();

        Debug.Log("SCORE : " + score);
    }

    void UpdateScoreText()
    {
        scoreText.text = "SCORE : " + score;
    }
}