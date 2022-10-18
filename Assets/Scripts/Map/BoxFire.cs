using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFire : MonoBehaviour
{
    private Animator fireAni;
    private void Start()
    {
        fireAni = GetComponent<Animator>();
        Switch switchPull = GetComponent<Switch>();
        switchPull.OnBoxTimerExpired += SwitchPullOnBoxTimerExpired;
    }

    private void SwitchPullOnBoxTimerExpired(object sender, EventArgs e)
    {
        fireAni.SetTrigger("BoxDie");
    }
}
