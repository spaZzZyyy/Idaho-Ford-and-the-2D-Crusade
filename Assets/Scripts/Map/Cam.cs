using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private Camera PartOne;
    [SerializeField] private Camera PartTwo;
    [SerializeField] AudioSource ears;
    [SerializeField] private AudioClip musicOne;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ears.Stop();
            ears.PlayOneShot(musicOne);
            PartOne.enabled = true;
            PartTwo.enabled = false;
        }
    }
    
}
