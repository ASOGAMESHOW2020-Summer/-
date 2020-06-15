using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otakara : MonoBehaviour
{
    private bool OtakaraFlag = false;

    private ThiefMoveScript thiefMoveScript;
    //使用制限
    private int OtakaraNum = 0;
    //カウントダウン
    public float countdown = 15.0f;
    void Start()
    {
        OtakaraFlag = false;
        thiefMoveScript = GetComponent<ThiefMoveScript>();
        //アイテム使用の初期化
        OtakaraNum = 0;
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
