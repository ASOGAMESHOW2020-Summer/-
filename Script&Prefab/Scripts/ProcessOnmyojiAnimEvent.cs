using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessOnmyojiAnimEvent : MonoBehaviour
{
    private OnmyojiMoveScript onmyoji;

  
    void Start()
    {
        onmyoji = GetComponent<OnmyojiMoveScript>();
    }

    public void EndDamage()
    {
        onmyoji.SetState(OnmyojiMoveScript.OnmyojiState.Normal);
    }
}
