using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGaugeCharacter : MonoBehaviour
{
    //　HP
    [SerializeField]
    private int hp;
    //　LifeGaugeスクリプト
    [SerializeField]
    private LifeGauge lifeGauge;


    // Start is called before the first frame update
    void Start()
    {
        //　体力の初期化
        hp = 3;
        //　体力ゲージに反映
        lifeGauge.SetLifeGauge(hp);
    }

    //　ダメージ処理メソッド（全削除＆HP分作成）
    public void Damage(int damage)
    {
        hp -= damage;
        //　0より下の数値にならないようにする
        hp = Mathf.Max(0, hp);

        if (hp >= 0)
        {
            lifeGauge.SetLifeGauge(hp);
        }
    }
}