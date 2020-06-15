using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    private bool KatanaFlag = false;
    private SamuraiMoveScript samuraiMoveScript;
    //カウントダウン
    public float countdown = 15.0f;
    //使用回数
    private int KatanaNum = 0;

    void Start()
    {
        samuraiMoveScript = GetComponent<samuraiMoveScript>();
        //刀フラグ初期化
        KatanaFlag = false;
        //刀の使用回数初期化
        KatanaNum = 0;
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
