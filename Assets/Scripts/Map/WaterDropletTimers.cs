using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropletTimers : MonoBehaviour
{
    private Animator waterAnimator;
    private SpriteRenderer waterSprites;
    // Start is called before the first frame update
    //Simple script to loop water time after five seconds
    void Start()
    {
        waterAnimator = GetComponent<Animator>();
        waterSprites = GetComponent<SpriteRenderer>();
        waterAnimator.SetBool("Play",false);
    }

    // Update is called once per frame
    void Update()
    {
        if (waterAnimator != null)
        {
            StartCoroutine(waterTimer());
        }
    }

    IEnumerator waterTimer()
    {
        waterAnimator.SetBool("Play",false);
        waterSprites.enabled = false;
        yield return new WaitForSeconds(5);
        waterSprites.enabled = true;
        waterAnimator.SetBool("Play",true);
    }
}
