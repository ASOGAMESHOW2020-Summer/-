/*一人プレイを選択したときのカメラ表示判定（SplitCamera.cs）
 * に使うフラグ処理スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleButton : MonoBehaviour
{
    public static bool SingleFlag = false;

    void Start()
    {
        SingleFlag = false;
    }

    public void OnClick()
    {
        SingleFlag = true;
    }
}
