using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gofu : MonoBehaviour
{
    private bool GofuFlag = false;

    void Start()
    {
        GofuFlag = false;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Onmyoji")
        {
            Destroy(gameObject);
            coll.GetComponent<OnmyojiMoveScript>().SetGofuFlag(true);
            GofuFlag = true;
            GetGofuFlag();
        }
        else
        {
            return;
        }
    }

    public bool GetGofuFlag()
    {
        return GofuFlag;
    }
}
