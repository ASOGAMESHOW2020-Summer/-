/*侍のアニムイベントを受け取るスクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessSamuraiAnimEvent : MonoBehaviour
{
    private SamuraiMoveScript samurai;
    [SerializeField]
    private CapsuleCollider capsulecollider;

    void Start()
    {
        samurai = GetComponent<SamuraiMoveScript>();

    }

    private void AttackStart()
    {
        capsulecollider.enabled = true;
    }

    void RunAttackEnd()
    {
        capsulecollider.enabled = false;
        samurai.SetState(SamuraiMoveScript.SamuraiState.Normal);
    }
    void AttackEnd()
    {
        capsulecollider.enabled = false;
    }
    
    void StateEnd()
    {
        samurai.SetState(SamuraiMoveScript.SamuraiState.Normal);
    }

    public void EndDamage()
    {
        samurai.SetState(SamuraiMoveScript.SamuraiState.Normal);
    }
}
