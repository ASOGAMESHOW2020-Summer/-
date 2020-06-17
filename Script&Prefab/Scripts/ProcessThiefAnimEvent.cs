using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessThiefAnimEvent : MonoBehaviour
{
    private ThiefMoveScript thief;

    void Start()
    {
        thief = GetComponent<ThiefMoveScript>();
    }

    public void EndDamage()
    {
        thief.SetState(ThiefMoveScript.ThiefState.Normal);
    }
}
