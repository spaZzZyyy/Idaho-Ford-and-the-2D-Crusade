using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTeleporter : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator m_animator;
    void Start()
    {
        WIn.win.OnPriestCast += WinOnOnPriestCast;
        m_animator = GetComponent<Animator>();
    }

    private void WinOnOnPriestCast()
    {
        m_animator.SetTrigger("Heal");
        PlayerMovement.Instance.transform.position = new Vector3(21,21,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
