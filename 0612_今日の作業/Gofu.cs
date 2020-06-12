﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gofu : MonoBehaviour
{
    private bool GofuFlag = false;
    //カウントダウン
    public float countdown = 15.0f;
    void Start()
    {
        GofuFlag = false;
    }

    void Update()
    {
        //時間をカウントする
        countdown -= Time.deltaTime;

        //カウントが0になった時
        if (countdown <= 0)
        {
            GofuFlag = false;
        }
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
