using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    private InputAction restart;
    private InputAction quit;
    private InputAction move;
    private InputAction shoot;

    [SerializeField] private float speed;
    private Vector2 moveInput;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float lives;
    [SerializeField] private TMP_Text livesText;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput.currentActionMap.Enable(); //enables action map

        move = playerInput.currentActionMap.FindAction("Move");
        restart = playerInput.currentActionMap.FindAction("Restart");
        quit = playerInput.currentActionMap.FindAction("Quit");
        shoot = playerInput.currentActionMap.FindAction("Shoot");

        move.started += Move_started;
        restart.performed += Restart_performed;
        quit.performed += Quit_performed;
        shoot.performed += Shoot_performed;

        move.canceled += Move_canceled;

        livesText.text = "Lives: " + lives.ToString();
    }
    /// <summary>
    /// cancels movement
    /// </summary>
    /// <param name="obj"></param>
    private void Move_canceled(InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<Vector2>();
    }

    /// <summary>
    /// Cancels all inputs on disable
    /// </summary>
    private void OnDisable()
    {

        move.performed -= Move_started;
        restart.performed -= Restart_performed;
        quit.performed -= Quit_performed;
        shoot.performed -= Shoot_performed;

        playerInput.currentActionMap.Disable();
    }

    /// <summary>
    /// Grabs move inputs
    /// </summary>
    /// <param name="obj"></param>
    private void Move_started(InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<Vector2>();
    }

    /// <summary>
    /// Spawns bullets, rotates and moves them
    /// </summary>
    /// <param name="context"></param>
    private void Shoot_performed(InputAction.CallbackContext context)
    {
        // spawns bullets
       

       
    }

    /// <summary>
    /// Loads the start screen
    /// </summary>
    /// <param name="context"></param>
    private void Quit_performed(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    ///  Restarts the scene
    /// </summary>
    /// <param name="context"></param>
    private void Restart_performed(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Controls player movement
    /// </summary>
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0f, moveInput.y * speed); //moves player

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

    }
    
}
