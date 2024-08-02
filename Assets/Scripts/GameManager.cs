using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int highScore;
    public float gameSpeedMultioplier { get; private set; }
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI endScoreTxt;
    [SerializeField] TextMeshProUGUI endHighscoreTxt;

    int currentScore;

    SpawnerManager spawnManag;
    MotionManager motionManag;

    private void Awake()
    {
        spawnManag = FindObjectOfType<SpawnerManager>();
        motionManag = FindObjectOfType<MotionManager>();
        
        gameSpeedMultioplier = 1;
        Time.timeScale = 1f;
        
        scoreTxt.text = currentScore.ToString();
        
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        gameOverScreen.SetActive(false);
    }

    public void IncreaseSpeed()
    {
        gameSpeedMultioplier += 0.1f;
        spawnManag.UpdateTimers();
        motionManag.UpdateTimers();
    }

    public void EndGame()
    {
        gameOverScreen.SetActive(true);
        endHighscoreTxt.text = highScore.ToString();

        endScoreTxt.text = currentScore.ToString();
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", currentScore);
        }

        Time.timeScale = 0f;
    }

    public void Score()
    {
        currentScore++;
        scoreTxt.text = currentScore.ToString();
    }
}
