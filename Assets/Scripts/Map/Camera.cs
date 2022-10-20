using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Camera PartOne;
    [SerializeField] private Camera PartTwo;
    [SerializeField] AudioSource ears;
    [SerializeField] private AudioClip musicTwo;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ears.Stop();
            ears.PlayOneShot(musicTwo);
            PartOne.enabled = false;
            PartTwo.enabled = true;
        }
    }
}
