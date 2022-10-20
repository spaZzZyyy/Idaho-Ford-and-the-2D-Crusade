using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatKill : MonoBehaviour
{
    public static BatKill batKill;

    private void Awake()
    {
        batKill = this;
    }

    public event Action killPlayerBat;

    public void batKillPlayer()
    {
        killPlayerBat?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            batKillPlayer();
        }
    }
}
