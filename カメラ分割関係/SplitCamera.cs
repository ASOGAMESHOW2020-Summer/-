using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCamera : MonoBehaviour
{
    //カメラステート
    public enum SplitCameraMode
    {
        TwoCamera,
        ThreeCamera,
        FourCamera
    };

    public SplitCameraMode mode;

    //プレイヤーを映すカメラ
    public Camera player1Camera;
    public Camera player2Camera;
    public Camera player3Camera;
    public Camera player4Camera;

  
    void Start()
    {
        //2人時のカメラ（横）分割
        if(mode == SplitCameraMode.TwoCamera)
        {
            //3,4P用のカメラは非表示
            player3Camera.gameObject.SetActive(false);
            player4Camera.gameObject.SetActive(false);
            //カメラのRectを変更
            //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
            player1Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
            player2Camera.rect = new Rect(0f, 0f, 1f, 0.5f);
        }
        //3人時のカメラ分割
        else if(mode == SplitCameraMode.ThreeCamera)
        {
            //4P用のカメラは非表示
            player4Camera.gameObject.SetActive(false);
            //カメラのRectを変更
            player1Camera.rect = new Rect(0f, 0.5f, 1f, 0.5f);
            player2Camera.rect = new Rect(0f, 0f, 1f, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
