using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    private bool KatanaFlag = false;
    //カウントダウン
    public float countdown = 15.0f;

    void Start()
    {
        KatanaFlag = false;
    }
    void Update()
    {
        //時間をカウントする
        countdown -= Time.deltaTime;

        //カウントが0になった時
        if(countdown<=0)
        {
            KatanaFlag = false;
        }
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
