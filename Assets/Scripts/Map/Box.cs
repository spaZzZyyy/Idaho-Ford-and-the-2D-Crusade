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
        SwitchTrigger.current.onSwitchPulled += CurrentOnonSwitchPulled;
        SwitchTrigger.current.onBoxDiesInFire += CurrentOnonBoxDiesInFire;
    }

    private void CurrentOnonBoxDiesInFire()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        boxAni.SetTrigger("BoxFire");
    }

    private void CurrentOnonSwitchPulled()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        boxAni.SetTrigger("SwitchPulled");
    }
    
}
