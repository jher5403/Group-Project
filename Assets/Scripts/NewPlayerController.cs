using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * I've essentailly merged the PlayerLogic and PlayerInputHandler scripts together to get my button inputs to work.
 * This script is responsible for handling all the player actions including movement, and weapons.
 * The input map is auto generated.
 * 
 * New Source: https://www.youtube.com/watch?v=HmXU4dZbaMw
 * Collision Logic Source: https://www.youtube.com/watch?v=Bc9lmHjqLZc
 */
public class NewPlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameOverManager gameOverManager;
    private PlayerInputActions playerControls;
    [SerializeField] private float moveSpeed = 7f;
    public Weapon autogun;
    public Weapon missile;

    /*
     * These InputActions represent all the possible actions the player can take.
     */
    private InputAction moveAction;
    private InputAction missileAction;
    private InputAction autogunAction;

    Vector2 MoveInput = Vector2.zero;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        moveAction = playerControls.Player.Move;
        missileAction = playerControls.Player.Missile;
        autogunAction = playerControls.Player.Autogun;
        SetInputActions();
    }

    /*
     * Responsible for movement. Sets the movement (velocity) of the RigidBody based on player input.
     * Either through the on screen controls or keyboard commands.
     */
    void OnMovement()
    {
        rb.velocity = new Vector2(MoveInput.x * moveSpeed, MoveInput.y * moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput = moveAction.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        OnMovement();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        missileAction.Enable();
        autogunAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        missileAction.Disable();
        autogunAction.Disable();
    }

    /*
     * Sets the behavior of an input action based on its state (Ex: performed, cancelled, waiting, etc)
     */
    private void SetInputActions()
    {
        missileAction.performed += FireMissile;
        autogunAction.performed += FireAutogun;
    }

    private void FireMissile(InputAction.CallbackContext context)
    {
        //Debug.Log("Fired Missile");

    }
    private void FireAutogun(InputAction.CallbackContext context)
    {
        //Debug.Log("Firing Autogun");
        autogun.Fire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Struck");
        gameOverManager.GameOver();
        Destroy(gameObject);
    }

}
