/*****************************************************************************
// File Name : ShootController.cs
// Author : Elodie Spangler
// Creation Date : September 1, 2025
//
// Brief Description : This script controls the bullets movements and what happens when it collides with somthing.
*****************************************************************************/
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float explosionDamage;
  

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    // <summary>
    /// controls enemy getting damage
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().TakeDamage(explosionDamage);

        }

        Destroy(gameObject); // Destroy the projectile after hitting
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() != null) //if collides with and object with enemy
                                                                          //controller
        {
            //Destroy(collision.gameObject); //it will distroy what it collides with
            Destroy(gameObject); //distorys itself 
            Debug.Log("enemy hits");


        }
        else if (collision.gameObject.tag == "Wall") //if bullet collides with object with wall tag
        {
            Destroy(gameObject); //destorys itself
        }
        else if (collision.gameObject.tag == "Bullet") // if bullet collides with object with bullet tag
        {
            Destroy(gameObject); //destroys itself
        }
    }
}
