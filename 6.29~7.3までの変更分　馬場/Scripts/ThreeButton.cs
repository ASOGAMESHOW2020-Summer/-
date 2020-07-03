/*三人プレイを選択したときのカメラ表示判定（SplitCamera.cs）
 * に使うフラグ処理スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeButton : MonoBehaviour
{
    public static bool ThreeFlag = false;

    void Start()
    {
        ThreeFlag = false;
    }

    public void OnClick()
    {
        ThreeFlag = true;
    }
}
