using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessMonkAnimEvent : MonoBehaviour
{
    private MonkMoveScript monk;

    void Start()
    {
        monk = GetComponent<MonkMoveScript>();
    }

    public void EndDamage()
    {
        monk.SetState(MonkMoveScript.MonkState.Normal);
    }
}
