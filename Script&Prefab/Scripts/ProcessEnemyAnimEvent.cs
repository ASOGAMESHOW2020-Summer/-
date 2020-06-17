﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessEnemyAnimEvent : MonoBehaviour
{
    private EnemyMoveScript enemy;
    [SerializeField]
    private SphereCollider sphereCollider;


    void Start()
    {
        enemy = GetComponent<EnemyMoveScript>();
    }

    public void AttackStart()
    {
        sphereCollider.enabled = true;
    }

    public void AttackEnd()
    {
        sphereCollider.enabled = false;
    }
    
    public void StateEnd()
    {
        enemy.SetState(EnemyMoveScript.EnemyState.Freeze);
    }

}