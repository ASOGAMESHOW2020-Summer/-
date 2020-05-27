using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessSamuraiAnimEvent : MonoBehaviour
{
    private SamuraiMoveScript samurai;

    void Start()
    {
        samurai = GetComponent<SamuraiMoveScript>();

    }

    public void EndDamage()
    {
        samurai.SetState(SamuraiMoveScript.SamuraiState.Normal);
    }
}
