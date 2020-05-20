using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour
{
   [Header("生成される敵を置いておく")]
    [SerializeField]
    GameObject[] enemys;
    [Header("次に敵が生成される時間")]
    [SerializeField]
    float appearNextTime;
    [Header("生成される敵の数")]
    [SerializeField]
    int maxNumOfEnemys;
    //何人の敵が生成されたか
    private int numberOfEnemys;
    //待ち時間計測
    private float elapsedTime;

    void Start()
    {
        //初期化
        numberOfEnemys = 0;
        elapsedTime = 0f;
    }

    void Update()
    {
        //生成する数を超えていたら何もしない
        if(numberOfEnemys >= maxNumOfEnemys)
        {
            return;
        }

        //経過時間を足す
        elapsedTime += Time.deltaTime;

        //経過時間が経ったら
        if(elapsedTime > appearNextTime)
        {
            elapsedTime = 0f;
            AppearEnemy();
        }
    }

    //敵生成
    void AppearEnemy()
    {
        //出現する敵をランダムにする（敵のモデルを増やした時用）
        var randomValue = Random.Range(0, enemys.Length);
        //出現させる敵の向きをランダムに設定
        var randomRotationY = Random.value * 360f;

        GameObject.Instantiate(enemys[randomValue], transform.position, Quaternion.Euler(0f, randomRotationY, 0f));

        numberOfEnemys++;
        elapsedTime = 0f;
    }
}

