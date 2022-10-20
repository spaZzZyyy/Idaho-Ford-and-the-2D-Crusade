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
    public float velocityY;
    private Animator m_animator;
    private float playerDirection;
    public static PlayerMovement Instance { get; private set; }

    //Adjustable movement Variables
    [SerializeField] private float jumpHeight;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;
    
    //Variables for Groundcheck
    private const float _groundCheckRadius = 0.2f;
    public bool isGrounded = false;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
        playerBody.transform.position = new Vector2(-8.1f, 0.68f);
        velocity = new Vector2(velocitySpeed, velocityY);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            m_animator.SetFloat("AnimState", 1f);
            MoveRight();
        }

        if (Input.GetKey((KeyCode.A)))
        {
            m_animator.SetFloat("AnimState", 1f);
            MoveLeft();
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
        GetComponent<SpriteRenderer>().flipX = false;
        velocitySpeed = 1f;
        playerBody.MovePosition(playerBody.position + velocity * Time.fixedDeltaTime * movementSpeed);
    }

    void MoveLeft()
    {
        GetComponent<SpriteRenderer>().flipX = true;
        velocitySpeed = -1f;
        playerBody.MovePosition(playerBody.position + velocity * Time.fixedDeltaTime * movementSpeed);
    }
    
    void Jump()
    {
        if (isGrounded == true)
        {
            m_animator.SetTrigger("Jump");
            m_animator.SetBool("Grounded", false);
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
            m_animator.SetBool("Grounded", true);
        }
    }

    void updateMovement()
    {
        velocityY = -1f;
        m_animator.SetFloat("AirSpeedY", -1);
        velocity = new Vector2(velocitySpeed, velocityY);
    }

    
}
