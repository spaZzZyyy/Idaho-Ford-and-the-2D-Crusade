using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class MonsterTemplate : MonoBehaviour, IMonsterAggro
{
    public int healthPoints;
    public float monsterSpeed;
    public float monsterRangeHorizontal;
    public Vector3 playerPosition;
    public int playerHealth = PlayerStats.Instance.playerHealth;
    private Animator monsterAnimator;
    [SerializeField] private float distanceToPlayer;

    public void StartUp()
    {
        monsterAnimator = GetComponent<Animator>();
    }
    public void Patrol()
    {
        playerPosition = PlayerStats.Instance.playerPosition;
        distanceToPlayer = Vector3.Distance(playerPosition, transform.position);
        if (distanceToPlayer <= monsterRangeHorizontal)
        {
            //Aggro to player
            monsterAnimator.SetTrigger("IsAggroed");
        }
        if (distanceToPlayer > monsterRangeHorizontal)
        {
            monsterAnimator.SetTrigger("LostAggro");
        }
    }

    public void Attack()
    {
        return;
    }
}
