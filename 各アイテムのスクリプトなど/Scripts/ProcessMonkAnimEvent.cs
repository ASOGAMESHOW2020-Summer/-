using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessMonkAnimEvent : MonoBehaviour
{
    private MonkMoveScript monk;
    // Start is called before the first frame update
    void Start()
    {
        monk = GetComponent<MonkMoveScript>();
    }

    public void EndDamage()
    {
        monk.SetState(MonkMoveScript.MonkState.Normal);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
