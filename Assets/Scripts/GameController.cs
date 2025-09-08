/*****************************************************************************
// File Name : GameController.cs
// Author : Elodie Spangler
// Creation Date : September 1, 2025
//
// Brief Description : This script controls score
*****************************************************************************/
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float score;
    
   

    /// <summary>
    /// Sets score text to "Score: "
    /// </summary>
    void Start()
    {
        

        scoreText.text = "Score: " + score.ToString(); //text 


    }

    /// <summary>
    /// Controlls score increase, score will increase by 100
    /// </summary>
    public void ScoreIncrease()
    {
        FindFirstObjectByType<ScoreManager>().AddScore(100);
        scoreText.text = "Score: " + score.ToString();


    }
}
