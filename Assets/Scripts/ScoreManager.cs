/*****************************************************************************
// File Name : ScoreManager.cs
// Author : Elodie Spangler
// Creation Date : September 1, 2025
//
// Brief Description : This script controls lives score and high score
*****************************************************************************/
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;
    private int highScore = 0;
    private bool newHighScoreTriggered = false;

    [SerializeField] private TMP_Text scoreText;               // Assign in Inspector
    [SerializeField] private TMP_Text highScoreText;          // Shows the saved high score
    [SerializeField] private TMP_Text highScoreAchievedText;  // Shows "High Score Achieved!"
    public int lives = 5;
    public TMP_Text livesText;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();

        // Hide the "High!" text at the start
        if (highScoreText != null)
            highScoreText.gameObject.SetActive(false);
        highScoreAchievedText.gameObject.SetActive(false);
        livesText.text = "Lives: " + lives.ToString();

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="amount"></param>
    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateUI();

        if (currentScore > highScore && !newHighScoreTriggered)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore: ", highScore);
            TriggerHighScoreMessage();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;
    }

    /// <summary>
    /// 
    /// </summary>
    public void TriggerHighScoreMessage()
    {
        newHighScoreTriggered = true;

        if (highScoreAchievedText != null)
        {
            highScoreAchievedText.text = "High Score Achieved: " + currentScore + "!";
            highScoreAchievedText.gameObject.SetActive(true);
        }


    }

    /// <summary>
    /// Controls lives when player collides with enemy
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
            lives -= 1;
            livesText.text = "Lives: " + lives.ToString();
        }
        else if (lives < 0)
        {

            TriggerHighScoreMessage ();

            livesText.text = "Lives: " + lives.ToString();
        }

    }

}
