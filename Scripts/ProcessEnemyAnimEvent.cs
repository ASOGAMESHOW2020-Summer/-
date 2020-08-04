/*エネミーのアニムイベントを受け取るスクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessEnemyAnimEvent : MonoBehaviour
{
    private NavMeshEnemyMove enemy;
    [SerializeField]
    private SphereCollider sphereCollider;


    void Start()
    {
        enemy = GetComponent<NavMeshEnemyMove>();
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
        enemy.SetState(NavMeshEnemyMove.EnemyState.Freeze);
    }

}
