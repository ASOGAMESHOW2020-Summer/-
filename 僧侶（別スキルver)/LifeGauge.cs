using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGauge : MonoBehaviour
{
    //　ライフゲージプレハブ
    [SerializeField]
    private GameObject lifeObj;

    //　ライフゲージ全削除＆HP分作成
    public void SetLifeGauge(int life)
    {
        //　体力を一旦全削除
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        //　現在の体力数分のライフゲージを作成
        for (int i = 0; i < life; i++)
        {
            Instantiate<GameObject>(lifeObj, transform);
        }
    }

    //ライフ回復
    public void LifeRecovery(int life)
    {
        //　体力を一旦全削除
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        //　現在の体力数分のライフゲージを作成
        for (int i = 0; i < life; i++)
        {
            Instantiate<GameObject>(lifeObj, transform);
        }
    }
}
