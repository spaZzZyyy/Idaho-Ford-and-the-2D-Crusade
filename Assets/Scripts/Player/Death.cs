using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    [SerializeField] int TimeAfterDeath;

    private Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        KillZone_Kill.killZone.OnPlayerEnterKillZone += KillZoneOnOnPlayerEnterKillZone;
        Kill.kill.OnPlayerKill += KillOnOnPlayerKill;
        BatKill.batKill.killPlayerBat += BatKillOnkillPlayerBat;
    }
    
    private void BatKillOnkillPlayerBat()
    {
        StartCoroutine(OnDeath());
    }

    private void KillOnOnPlayerKill()
    {
        StartCoroutine(OnDeath());
    }

    private void KillZoneOnOnPlayerEnterKillZone()
    {
        StartCoroutine(OnDeath());
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator OnDeath()
    {
        m_animator.SetTrigger("Death");
        yield return new WaitForSeconds(TimeAfterDeath);
        LoadCurrentScene();
    }
}
