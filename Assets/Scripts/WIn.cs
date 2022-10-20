using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WIn : MonoBehaviour
{
    public static WIn win;
    [SerializeField] private GameObject winMsg;
    private void Awake()
    {
        winMsg.GetComponent<SpriteRenderer>().enabled = true;
        win = this;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            winMsg.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(winTeleport());
        }
    }

    public event Action OnPriestCast;

    public void priestCast()
    {
        OnPriestCast?.Invoke();
    }
    IEnumerator winTeleport()
    {
        yield return new WaitForSeconds(3);
        priestCast();
    }
}
