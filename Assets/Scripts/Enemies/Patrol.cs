using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float speed;
    private bool _direction; //true is right, False is left
    public static Patrol Instance { get; private set; }

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

    //Initial goals:
    //Add jumping
    //Turn around when hitting a wall

    private void FixedUpdate()
    {
        if (_direction == true)
        {
            OnMoveRight(playerRigidbody);
        } else if (_direction == false)
        {
            OnMoveLeft(playerRigidbody);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            OnDirectionChange();
        }
    }

    void OnDirectionChange()
    {
        if (_direction == true)
        {
            _direction = false;
        } else if (_direction == false)
        {
            _direction = true;
        }
    }
    void OnMoveRight(Rigidbody2D playerRigidbody)
    {
        playerRigidbody.AddForce(Vector2.right * (Time.fixedDeltaTime * speed));
        transform.localScale = new Vector3(2, transform.localScale.y, transform.localScale.z);
    }
    
    void OnMoveLeft(Rigidbody2D playerRigidbody)
    {
        playerRigidbody.AddForce(Vector2.left * (Time.fixedDeltaTime * speed));
        transform.localScale = new Vector3(-2, transform.localScale.y, transform.localScale.z);
    }
}
