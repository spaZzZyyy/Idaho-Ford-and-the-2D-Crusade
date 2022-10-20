using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public static Kill kill;

    private void Awake()
    {
        kill = this;
    }

    public event Action OnPlayerKill;

    public void killPlayer()
    {
        OnPlayerKill?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            killPlayer();
        }
    }
}
