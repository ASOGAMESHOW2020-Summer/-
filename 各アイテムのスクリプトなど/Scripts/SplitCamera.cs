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

    //カメラ用の枠
    public Transform waku1;
    public Transform waku2;
    public Transform waku3;
    public Transform waku4;
    // Start is called before the first frame update
    void Start()
    {
        //2人時のカメラ（横）分割
        if (mode == SplitCameraMode.TwoCamera)
        {
            //3,4P用のカメラは非表示
            player3Camera.gameObject.SetActive(false);
            player4Camera.gameObject.SetActive(false);
            //カメラのRectを変更
            //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
            player1Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
            player2Camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);

            //枠の幅を変更する
            var waku1Rect = waku1.Find("Right").GetComponent<RectTransform>();
            waku1Rect.localScale = new Vector3(waku1Rect.localScale.x / 2f, waku1Rect.localScale.y, waku1Rect.localScale.z);

            var waku2Rect = waku2.Find("Left").GetComponent<RectTransform>();
            waku2Rect.localScale = new Vector3(waku2Rect.localScale.x / 2f, waku2Rect.localScale.y, waku2Rect.localScale.z);

        }
        //3人時のカメラ分割
        else if (mode == SplitCameraMode.ThreeCamera)
        {
            //4P用のカメラは非表示
            player4Camera.gameObject.SetActive(false);
            // player3Camera.gameObject.SetActive(false);
            //カメラのRectを変更
            player1Camera.rect = new Rect(0f, 0.5f, 1f, 0.5f);
            player2Camera.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
            player3Camera.rect = new Rect(0f, 0f, 0.5f, 0.5f);

            //カメラの枠変更
            var waku1Rect = waku1.Find("Bottom").GetComponent<RectTransform>();
            waku1Rect.localScale = new Vector3(waku1Rect.localScale.x, waku1Rect.localScale.y / 2f, waku1Rect.localScale.z);

            var waku2Rect = waku2.Find("Top").GetComponent<RectTransform>();
            waku2Rect.localScale = new Vector3(waku2Rect.localScale.x, waku2Rect.localScale.y / 2f, waku2Rect.localScale.z);

            var waku3Rect = waku3.Find("Top").GetComponent<RectTransform>();
            waku3Rect.localScale = new Vector3(waku3Rect.localScale.x, waku3Rect.localScale.y / 2f, waku3Rect.localScale.z);
            waku3Rect = waku3.Find("Right").GetComponent<RectTransform>();
            waku3Rect.localScale = new Vector3(waku3Rect.localScale.x / 2f, waku3Rect.localScale.y, waku3Rect.localScale.z);

        }
        //4人時のカメラ分割
        else if (mode == SplitCameraMode.FourCamera)
        {
            player1Camera.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
            player2Camera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            player3Camera.rect = new Rect(0f, 0f, 0.5f, 0.5f);
            player4Camera.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);

            //枠の幅を変更する
            var waku1Rect = waku1.Find("Bottom").GetComponent<RectTransform>();
            waku1Rect.localScale = new Vector3(waku1Rect.localScale.x, waku1Rect.localScale.y / 2f, waku1Rect.localScale.z);
            waku1Rect = waku1.Find("Right").GetComponent<RectTransform>();
            waku1Rect.localScale = new Vector3(waku1Rect.localScale.x / 2f, waku1Rect.localScale.y, waku1Rect.localScale.z);

            var waku2Rect = waku2.Find("Bottom").GetComponent<RectTransform>();
            waku2Rect.localScale = new Vector3(waku2Rect.localScale.x, waku2Rect.localScale.y / 2f, waku2Rect.localScale.z);
            waku2Rect = waku2.Find("Left").GetComponent<RectTransform>();
            waku2Rect.localScale = new Vector3(waku2Rect.localScale.x / 2f, waku2Rect.localScale.y, waku2Rect.localScale.z);

            var waku3Rect = waku3.Find("Top").GetComponent<RectTransform>();
            waku3Rect.localScale = new Vector3(waku3Rect.localScale.x, waku3Rect.localScale.y / 2f, waku3Rect.localScale.z);
            waku3Rect = waku3.Find("Right").GetComponent<RectTransform>();
            waku3Rect.localScale = new Vector3(waku3Rect.localScale.x / 2f, waku3Rect.localScale.y, waku3Rect.localScale.z);

            var waku4Rect = waku4.Find("Top").GetComponent<RectTransform>();
            waku4Rect.localScale = new Vector3(waku4Rect.localScale.x, waku4Rect.localScale.y / 2f, waku4.localScale.z);
            waku4Rect = waku4.Find("Left").GetComponent<RectTransform>();
            waku4Rect.localScale = new Vector3(waku4Rect.localScale.x / 2f, waku4Rect.localScale.y, waku4Rect.localScale.z);

        }
    }
    public SplitCameraMode GetState()
    {
        return mode;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
