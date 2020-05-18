﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    //初期位置
    private Vector3 startposition;
    //目的地
    private Vector3 destination;

   
    void Start()
    {
        //初期位置を設定
        startposition = transform.position;
        SetDestination(transform.position);
    }

    //ランダムな位置の作成
    public void CreateRandomPosition()
    {
        //ランダムなVectorの値を得る
        var randDestination = Random.insideUnitCircle * 10;
        //現在位置にランダムな位置を足して目的地とする
        SetDestination(startposition + new Vector3(randDestination.x, 0, randDestination.y));
    }

    //目的地を設定する
    public void SetDestination(Vector3 position)
    {
        destination = position;
    }

    //目的地を取得する
    public Vector3 getDestination()
    {
        return destination;
    }
}