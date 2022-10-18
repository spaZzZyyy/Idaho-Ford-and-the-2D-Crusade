using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float ladderSpeed;

    private void OnTriggerEnter2D(Collider2D col)
    {
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += new Vector3(0, ladderSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position += new Vector3(0, -ladderSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
