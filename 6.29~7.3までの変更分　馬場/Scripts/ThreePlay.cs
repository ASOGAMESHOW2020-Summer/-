/*シーン遷移スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThreePlay : MonoBehaviour
{
    public static bool ThreeFlag = false;

    void Start()
    {
        //シーンが切り替わってもオブジェクトを削除しない
        DontDestroyOnLoad(this);
        ThreeFlag = false;
    }

    public void OnClick()
    {
        ThreeFlag = true;
        SceneManager.LoadScene("ThreeCharacterSelect");
    }

}
