using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    [SerializeField] int TimeAfterDeath;
    // Start is called before the first frame update
    void Start()
    {
        KillZone_Kill deathZone = GetComponent<KillZone_Kill>();
        if (deathZone != null)
        {
            deathZone.OnPlayerEnterKillZone += DeathZoneOnOnPlayerEnterKillZone;
        }
    }

    private void DeathZoneOnOnPlayerEnterKillZone(object sender, EventArgs e)
    {
        StartCoroutine(OnDeath());
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator OnDeath()
    {
        yield return new WaitForSeconds(TimeAfterDeath);
        LoadCurrentScene();
    }
}
