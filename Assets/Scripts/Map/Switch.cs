using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    Animator switchAnimator;
    private bool canPullSwitch;
    private bool bridgeSwitch;
    private void Start()
    {
        switchAnimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            canPullSwitch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canPullSwitch = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPullSwitch == true)
        {
            Debug.Log("Switch Pulled");
            SwitchTrigger.current.SwitchPulled();
            switchAnimator.SetBool("OnTriggered", true);
            StartCoroutine(BridgeReset());
        }
        
    }

    IEnumerator BridgeReset()
    {
        yield return new WaitForSeconds(3);
        switchAnimator.SetBool("OnTriggered", false);
        SwitchTrigger.current.boxDeath();
    }
}
