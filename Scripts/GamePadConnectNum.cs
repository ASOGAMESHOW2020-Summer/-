/*ゲームパッドの接続された数を認識するスクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GamePadConnectNum : MonoBehaviour
{
    private string[] JoystickNames;
    //ゲームパッド使用フラグ
    public static bool pad1 = false,pad2 = false,pad3 = false,pad4 = false;
    //ゲームパッドのカウント
    private int connectCount = 0;

    void Start()
    {   
        //Input.GetJoystickNamesで接続されたジョイスティックの配列を返す     
        JoystickNames = Input.GetJoystickNames();
        connectCount = 0;
    }

    void Update()
    {
        for (int i = 0; i < JoystickNames.Length; i++)
        {
            //誤ってっ生清されたコントローラは除外してカウントする
            if (JoystickNames[i] != "")
            {
                connectCount++;
            }
        }

        //ゲームパッドがカウントされたらゲームパッド使用フラグをtrueにする
        if (connectCount == 1)
        {
            pad1 = true;
        }
        else if(connectCount == 2)
        {
            pad2 = true;
        }
        else if(connectCount == 3)
        {
            pad3 = true;
        }
        else if(connectCount == 4)
        {
            pad4 = true;
        }
    }
}
