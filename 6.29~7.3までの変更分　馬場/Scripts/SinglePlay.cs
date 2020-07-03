/*シーン遷移スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlay : MonoBehaviour
{
    public static bool SingleFlag = false;

    void Start()
    {
        //シーンが切り替わってもオブジェクトを削除しない
        DontDestroyOnLoad(this);
        SingleFlag = false;
    }

    public void OnClick()
    {
        SingleFlag = true;
        //ここで移りたいシーンを指定
        SceneManager.LoadScene("SingleCharacterSelect");
    }

}
