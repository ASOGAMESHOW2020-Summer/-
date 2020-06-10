using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butsuzo : MonoBehaviour
{
    private bool ButsuzoFlag = false;

    void Start()
    {
        ButsuzoFlag = false;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Monk")
        {
            Destroy(gameObject);
            coll.GetComponent<MonkMoveScript>().SetButsuzoFlag(true);
            ButsuzoFlag = true;
            GetButsuzoFlag();
        }
        else
        {
            return;
        }
    }

    public bool GetButsuzoFlag()
    {
        return ButsuzoFlag;
    }
}
