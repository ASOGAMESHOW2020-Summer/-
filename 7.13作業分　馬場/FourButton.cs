/*四人プレイを選択したときのカメラ表示判定（SplitCamera.cs）
 * に使うフラグ処理スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FourButton : MonoBehaviour
{
    public static bool FourFlag = false;

    void Start()
    {
        FourFlag = false;
    }

    public void OnClick()
    {
        FourFlag = true;
    }
}
