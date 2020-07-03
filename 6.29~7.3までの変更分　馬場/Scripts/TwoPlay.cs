/*シーン遷移スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TwoPlay : MonoBehaviour
{
    public static bool TwoFlag = false;

    void Start()
    {
        //シーンが切り替わってもオブジェクトを削除しない
        DontDestroyOnLoad(this);
        TwoFlag = false;
    }

    public void OnClick()
    {
        TwoFlag = true;
        SceneManager.LoadScene("TwoCharacterSelect");
    }

}
