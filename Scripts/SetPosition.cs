/*エネミーの移動先を設定するスクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    //　初期位置
    private Vector3 startPosition;
    //　目的地
    private Vector3 destination;


    void Start()
    {
        //初期位置を設定
        startPosition = transform.position;
        SetDestination(transform.position);
    }

    //ランダムな位置の作成
    public void CreateRandomPosition()
    {
        //ランダムなVectorの値を得る
        //var randDestination = Random.insideUnitCircle * 500;
        ////現在位置にランダムな位置を足して目的地とする
        //SetDestination(startPosition + new Vector3(randDestination.x, 0, randDestination.y));
        var randDestinationX = Random.Range(75.0f, 315.0f);
        var randDestinationZ = Random.Range(30.0f, 540.0f);
        SetDestination(startPosition + new Vector3(randDestinationX, 0, randDestinationZ));
    }

    //目的地を設定する
    public void SetDestination(Vector3 position)
    {
        destination = position;
    }

    //目的地を取得する
    public Vector3 GetDestination()
    {
        return destination;
    }
}

