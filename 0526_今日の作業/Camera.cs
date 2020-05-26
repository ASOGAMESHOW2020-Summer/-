using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //カメラの分割方法
    public enum SplitCameraMode
    {
        horizontal,
        vertical,
        square
    };

    public SplitCameraMode mode; //カメラの分割方法

    //プレイヤーを写すそれぞれのカメラ
    public Camera playerCamera1;
    public Camera playerCamera2;
    public Camera playerCamera3;
    public Camera playerCamera4;

    // Start is called before the first frame update
    void Start()
    {
        //2プレイヤー用の横分割
        if(mode == SplitCameraMode.horizontal)
        {
            //カメラ3、4は非表示
            playerCamera3.gameObject.SetActive(false);
            playerCamera4.gameObject.SetActive(false);
            //カメラのViewPortRectの変更
            playerCamera1.rect = new Rect(0f, 0f, 0.5f, 1f);
            playerCamera2.rect = new Rect(0.5f, 0f, 0.5f, 1f);
        }
        //2プレイヤー用の縦分割
        else if(mode == SplitCameraMode.vertical)
        {
            //カメラ3、4は非表示
            playerCamera3.gameObject.SetActive(false);
            playerCamera4.gameObject.SetActive(false);
            //カメラのViewPortRectの変更
            playerCamera1.rect = new Rect(0f, 0.5f, 1f, 0.5f);
            playerCamera2.rect = new Rect(0f, 0f, 1f, 0.5f);
        }
        //4プレイヤー用の４分割
        else if(mode == SplitCameraMode.square)
        {
            playerCamera1.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
            playerCamera2.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            playerCamera3.rect = new Rect(0f, 0f, 0.5f, 0.5f);
            playerCamera4.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
