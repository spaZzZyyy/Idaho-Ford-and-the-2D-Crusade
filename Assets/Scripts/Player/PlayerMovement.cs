using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables to function
    private Rigidbody2D playerBody;
    private Vector2 velocity;
    private float velocitySpeed = 1f;
    private float velocityY;

    //Adjustable movement Variables
    [SerializeField] private float jumpHeight;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;
    
    //Variables for Groundcheck
    private const float _groundCheckRadius = 0.2f;
    private bool isGrounded = false;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerBody.transform.position = new Vector2(-8.1f, 0.68f);
        velocity = new Vector2(velocitySpeed, velocityY);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey((KeyCode.A)))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.S))
        {
            Crouch();
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        GroundCheck();
        updateMovement();
    }

    void MoveRight()
    {
        velocitySpeed = 1f;
        playerBody.MovePosition(playerBody.position + velocity * Time.fixedDeltaTime * movementSpeed);
    }

    void MoveLeft()
    {
        velocitySpeed = -1f;
        playerBody.MovePosition(playerBody.position + velocity * Time.fixedDeltaTime * movementSpeed);
    }

    void Crouch()
    {
        
    }

    void Jump()
    {
        if (isGrounded == true)
        {
            Vector2 apexJump = playerBody.position + new Vector2(0, jumpHeight);
            transform.position = Vector2.Lerp(transform.position, apexJump, jumpSpeed);
        }
    }
    
    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, _groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }

    void updateMovement()
    {
        velocityY = -1f;
        velocity = new Vector2(velocitySpeed, velocityY);
    }

    
}
