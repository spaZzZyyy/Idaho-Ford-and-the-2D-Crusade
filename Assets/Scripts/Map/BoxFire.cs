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
        SwitchTrigger.current.onBoxDiesInFire += CurrentOnonBoxDiesInFire;
    }

    private void CurrentOnonBoxDiesInFire()
    {
        fireAni.SetTrigger("BoxDie");
    }
}
