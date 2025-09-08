/*****************************************************************************
// File Name : EnemyController.cs
// Author : Elodie Spangler
// Creation Date : September 1, 2025
//
// Brief Description : This script controls what happens whenthe enemy collides with certain objects 

*****************************************************************************/
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject enemy;
    private GameController gameController;
    private PlayerController playerController;
    [SerializeField] private float health;
    
    private Rigidbody2D rb;

    /// <summary>
    /// calls player controller 
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * speed;

        gameController = FindFirstObjectByType<GameController>();
        playerController = FindFirstObjectByType<PlayerController>();



    }

    /// <summary>
    /// contolls enemy taking damage
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        health -= damage;


        if (health <= 0)
        {
            Destroy(gameObject); // Enemy dies
        }
    }

    /// <summary>
    /// Controlls what happens when enemy collides with certain objects
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null) //if enemy collides with player
        {
            Destroy(enemy); // destroys enemy


        }
        else if (collision.gameObject.GetComponent<ShootController>() != null) // if enemy collides with bullet
        {
            gameController.ScoreIncrease(); //increases score
            TakeDamage(health);
            Debug.Log("Bullet hits");

        }
        else if (collision.gameObject.tag == "Wall") // if enemy collides with wall
        {
            Destroy(enemy); // destroys enemy
        }



    }
}
