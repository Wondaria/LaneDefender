using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject enemy;
    
    private PlayerController playerController;
    [SerializeField] private float health;

    /// <summary>
    /// calls player controller 
    /// </summary>
    void Start()
    {
       
        

      


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
            //gameController.ScoreIncrease(); //increases score
            TakeDamage(health);


        }
        else if (collision.gameObject.tag == "Wall") // if enemy collides with wall
        {
            Destroy(enemy); // destroys enemy
        }



    }
}
