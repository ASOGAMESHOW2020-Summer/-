﻿/*ゲームプレイ中の名前UIの表示スクリプト（陰陽師）*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnmyojiName : MonoBehaviour
{
    [SerializeField]
    private Text text;
   
    void Start()
    {
        text = this.GetComponent<Text>();
    }


    void Update()
    {
        if (OnmyojiButton.OnmyojiFlag == true)
        {
            text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (OnmyojiButton.OnmyojiFlag == false)
        {
            text.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}