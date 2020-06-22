using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessOnmyojiAnimEvent : MonoBehaviour
{
    private OnmyojiMoveScript onmyoji;
    // Start is called before the first frame update
    void Start()
    {
        onmyoji = GetComponent<OnmyojiMoveScript>();
    }

    public void EndDamage()
    {
        onmyoji.SetState(OnmyojiMoveScript.OnmyojiState.Normal);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
