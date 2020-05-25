using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessPlayerAnimEvent : MonoBehaviour
{
    private CharacterMoveScript character;
  
    void Start()
    {
        character = GetComponent<CharacterMoveScript>();
    }

    public void EndDamage()
    {
        character.SetState(CharacterMoveScript.MyState.Normal);
    }
}
