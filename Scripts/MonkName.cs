﻿/*ゲームプレイ中の名前UIの表示スクリプト（僧侶）*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonkName : MonoBehaviour
{
    [SerializeField]
    private Text text;
   
    void Start()
    {
        text = this.GetComponent<Text>();
    }


    void Update()
    {
        if(MonkButton.MonkFlag == true)
        {
            text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (MonkButton.MonkFlag == false)
        {
            text.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}