using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class MonsterTemplate : MonoBehaviour
{
    protected Rigidbody2D monsterBody;
    protected float monsterSpeed;
    protected bool _direction;

    protected void OnMoveRight(Rigidbody2D monsterRigidbody)
    {
        Debug.Log("MovingRight");
        monsterRigidbody.AddForce(Vector2.right * (Time.fixedDeltaTime * monsterSpeed));
        transform.localScale = new Vector3(2, transform.localScale.y, transform.localScale.z);
    }
    
    protected void OnMoveLeft(Rigidbody2D monsterRigidbody)
    {
        monsterRigidbody.AddForce(Vector2.left * (Time.fixedDeltaTime * monsterSpeed));
        transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
    }
    
    protected void OnDirectionChange()
    {
        if (_direction == true)
        {
            _direction = false;
        } else if (_direction == false)
        {
            _direction = true;
        }
    }
}
