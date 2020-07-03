﻿/*二人プレイを選択したときのカメラ表示判定（SplitCamera.cs）
 * に使うフラグ処理スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoButton : MonoBehaviour
{
    public static bool TwoFlag = false;

    void Start()
    {
        TwoFlag = false;
    }

    public void OnClick()
    {
        TwoFlag = true;
    }
}
