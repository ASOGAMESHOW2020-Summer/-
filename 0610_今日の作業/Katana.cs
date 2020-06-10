using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    private bool KatanaFlag = false;

    void Start()
    {
        KatanaFlag = false;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Samurai")
        {
            Destroy(gameObject);
            coll.GetComponent<SamuraiMoveScript>().SetKatanaFlag(true);
            KatanaFlag = true;
            GetKatanaFlag();
        }
        else
        {
            return;
        }
    }

    public bool GetKatanaFlag()
    {
        return KatanaFlag;
    }
}
