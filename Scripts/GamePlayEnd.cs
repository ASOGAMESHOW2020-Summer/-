/*ゲームを終了させるスクリプト（デバッグ用）*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayEnd : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("終わり");
            GamePlayQuit();
        }
    }
    public void GamePlayQuit()
    {
        Application.Quit();
    }
}
