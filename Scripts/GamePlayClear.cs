/*ゲームをクリア状態にするスクリプト（デバッグ用）*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayClear : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("終わり");
            Clear();
        }
    }
    public void Clear()
    {
        SceneManager.LoadScene("Clear");
    }
}
