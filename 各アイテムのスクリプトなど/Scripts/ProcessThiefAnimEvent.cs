using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessThiefAnimEvent : MonoBehaviour
{
    private ThiefMoveScript thief;
    // Start is called before the first frame update
    void Start()
    {
        thief = GetComponent<ThiefMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        thief.SetState(ThiefMoveScript.ThiefState.Normal);
    }
}
