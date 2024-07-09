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
    private bool fireMissile;
    private bool fireAutogun;

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

        fireMissile = inputHandler.MissileTriggered && fireMissile;
        fireAutogun = inputHandler.AutogunTriggered && fireAutogun;
    }

    private void FixedUpdate()
    {
        ApplyMovement();

        if (fireMissile) 
        { 
            FireMissile(); 
        }

        if (fireAutogun) 
        { 
            FireAutogun(); 
        }
    }

    void ApplyMovement()
    {
        rb.velocity = new Vector2 (horizontalInput * moveSpeed, verticalInput * moveSpeed);
        Debug.Log("New Movement");
    }

    void FireMissile() // Q
    {
        Debug.Log("Firing Missile!");
        fireMissile = false;
    }

    void FireAutogun() // E
    {
        Debug.Log("Firing Autogun!");
        fireAutogun = false;
    }
}
