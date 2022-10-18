using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone_Kill : MonoBehaviour
{
    public event EventHandler OnPlayerEnterKillZone;
    //Script design to kill the player if they enter this zone
    //This script sends an event that shows the player Entered the Killzone
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            OnPlayerEnterKillZone?.Invoke(this, EventArgs.Empty);
            Debug.Log("Died");
        }
    }
}
