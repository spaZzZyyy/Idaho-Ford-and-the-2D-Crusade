using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    Animator switchAnimator;
    public event EventHandler OnSwitchPulled;
    public event EventHandler OnBoxTimerExpired;
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
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space) && canPullSwitch)
        {
            Debug.Log("Switch Pulled");
            switchAnimator.SetBool("OnTriggered", true);
            OnSwitchPulled?.Invoke(this, EventArgs.Empty);
            StartCoroutine(BridgeReset());
        }
    }

    IEnumerator BridgeReset()
    {
        yield return new WaitForSeconds(3);
        switchAnimator.SetBool("OnTriggered", false);
        OnBoxTimerExpired?.Invoke(this, EventArgs.Empty);
    }
}
