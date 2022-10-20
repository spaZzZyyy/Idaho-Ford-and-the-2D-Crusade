using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public static SwitchTrigger current;

    private void Awake()
    {
        current = this;
    }

    public event Action onSwitchPulled;
    public void SwitchPulled()
    {
        onSwitchPulled?.Invoke();
    }

    public event Action onBoxDiesInFire;

    public void boxDeath()
    {
        onBoxDiesInFire?.Invoke();
    }
}
