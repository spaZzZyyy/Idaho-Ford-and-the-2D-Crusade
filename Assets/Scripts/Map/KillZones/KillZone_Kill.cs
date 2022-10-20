using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone_Kill : MonoBehaviour
{
    public static KillZone_Kill killZone;
    public bool playerAlive = true;
    private void Awake()
    {
        killZone = this;
    }

    public event Action OnPlayerEnterKillZone;

    public void enteredDeath()
    {
        playerAlive = false;
        OnPlayerEnterKillZone?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        enteredDeath();
    }
}
