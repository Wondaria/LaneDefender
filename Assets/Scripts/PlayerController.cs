/*****************************************************************************
// File Name : PlayerController.cs
// Author : Elodie Spangler
// Creation Date : September 1, 2025
//
// Brief Description : This script controls player movement and actions
*****************************************************************************/
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
    
    [SerializeField] private TMP_Text livesText;
    private GameController gameController;
    private PlayerController playerController;
    private ScoreManager scoreManager;


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

       

        gameController = FindFirstObjectByType<GameController>();
        playerController = FindFirstObjectByType<PlayerController>();
        
        scoreManager = FindFirstObjectByType<ScoreManager>();
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
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);



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

    
    
}
