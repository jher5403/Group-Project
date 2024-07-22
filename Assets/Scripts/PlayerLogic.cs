/*
 * Is responible for all player actions. Movement, button actions, etc.
 * Still a work in progress.
 * Buttons probably need to be handled as Context action rather than boolean.
 * 
 * Source: https://www.youtube.com/watch?v=lclDl-NGUMg (part of the InputAction video)
 * Old Source (Not Used): https://www.youtube.com/watch?v=ixM2W2tPn6c
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInputHandler inputHandler;
    [SerializeField] private float moveSpeed = 7f;
    private float horizontalInput;
    private float verticalInput;
    private bool shouldMissile;
    private bool shouldAutogun;

    private void Start()
    {
        Awake();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = PlayerInputHandler.Instance;
    }

    private void Update()
    {
        horizontalInput = inputHandler.MoveInput.x;
        verticalInput = inputHandler.MoveInput.y;

        shouldMissile = inputHandler.MissileTriggered;
        shouldAutogun = inputHandler.AutogunTriggered;
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        FireMissile();
        FireAutogun();
        
    }

    void ApplyMovement()
    {
        rb.velocity = new Vector2 (horizontalInput * moveSpeed, verticalInput * moveSpeed);
    }

    /*
     * fireMissile starts as false. Inputs do not change it. Perhaps I am going about this wrong.
     */
    void FireMissile() // Q
    {
        if (shouldMissile == true) 
        {
            Debug.Log("Missile");
            shouldMissile = false;
        }
    }

    void FireAutogun() // E
    {
        if (shouldAutogun == true) 
        {
            Debug.Log("Autogun");
            shouldAutogun = false;
        }
    }
}
