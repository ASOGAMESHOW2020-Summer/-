using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otakara : MonoBehaviour
{
    private bool OtakaraFlag = false;
    //カウントダウン
    public float countdown = 15.0f;
    void Start()
    {
        OtakaraFlag = false;
    }

    void Update()
    {
        //時間をカウントする
        countdown -= Time.deltaTime;

        //カウントが0になった時
        if (countdown <= 0)
        {
            OtakaraFlag = false;
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Thief")
        {
            Destroy(gameObject);
            coll.GetComponent<ThiefMoveScript>().SetOtakaraFlag(true);
            OtakaraFlag = true;
            GetOtakaraFlag();
        }
        else
        {
            return;
        }
    }

    public bool GetOtakaraFlag()
    {
        return OtakaraFlag;
    }
}
