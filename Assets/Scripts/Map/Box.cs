using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Animator boxAni;
    
    private void Start()
    {
        boxAni = GetComponent<Animator>();
        Switch switchPull = GetComponent<Switch>();
        if (switchPull != null)
        {
            switchPull.OnSwitchPulled += SwitchPullOnSwitchPulled;
            switchPull.OnBoxTimerExpired += SwitchPullOnBoxTimerExpired;
        }
    }
    
    private void SwitchPullOnBoxTimerExpired(object sender, EventArgs e)
    {
        boxAni.SetTrigger("BoxFire");
        Debug.Log("wtf");
    }

    private void SwitchPullOnSwitchPulled(object sender, EventArgs e)
    {
        Debug.Log("Drop");
        boxAni.SetTrigger("SwitchPulled");
    }
}
