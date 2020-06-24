using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCamera : MonoBehaviour
{
    //カメラステート
    public enum SplitCameraMode
    {
        OneCamera,
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

    private void Awake()
    {
        if (SingleButton.SingleFlag == true)
        {
            mode = SplitCameraMode.OneCamera;
        }
        else if (TwoButton.TwoFlag == true)
        {
            mode = SplitCameraMode.TwoCamera;
        }
        else if (ThreeButton.ThreeFlag == true)
        {
            mode = SplitCameraMode.ThreeCamera;
        }
        else if (FourButton.FourFlag == true)
        {
            mode = SplitCameraMode.FourCamera;
        }
    }

    void Start()
    {
        //1人時のカメラ
        if(mode == SplitCameraMode.OneCamera)
        {
            if(SamuraiButton.SamuraiFlag == true)
            {
                //2,3,4P用のカメラは非表示
                player2Camera.gameObject.SetActive(false);
                player3Camera.gameObject.SetActive(false);
                player4Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player1Camera.rect = new Rect(0f, 0f, 1f, 1f);
                //枠の幅を変更する
                var waku1Rect = waku1.Find("Top").GetComponent<RectTransform>();
                waku1Rect.localScale = new Vector3(waku1Rect.localScale.x, waku1Rect.localScale.y, waku1Rect.localScale.z);
            }
            else if(MonkButton.MonkFlag == true)
            {
                //1,3,4P用のカメラは非表示
                player1Camera.gameObject.SetActive(false);
                player3Camera.gameObject.SetActive(false);
                player4Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player2Camera.rect = new Rect(0f, 0f, 1f, 1f);
                //枠の幅を変更する
                var waku2Rect = waku2.Find("Top").GetComponent<RectTransform>();
                waku2Rect.localScale = new Vector3(waku2Rect.localScale.x, waku2Rect.localScale.y, waku2Rect.localScale.z);
            }
            else if(OnmyojiButton.OnmyojiFlag == true)
            {
                //1,2,4P用のカメラは非表示
                player1Camera.gameObject.SetActive(false);
                player2Camera.gameObject.SetActive(false);
                player4Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player3Camera.rect = new Rect(0f, 0f, 1f, 1f);
                //枠の幅を変更する
                var waku3Rect = waku3.Find("Top").GetComponent<RectTransform>();
                waku3Rect.localScale = new Vector3(waku3Rect.localScale.x, waku3Rect.localScale.y, waku3Rect.localScale.z);
            }
            else if (ThiefButton.ThiefFlag == true)
            {
                //1,2,3P用のカメラは非表示
                player1Camera.gameObject.SetActive(false);
                player2Camera.gameObject.SetActive(false);
                player3Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player4Camera.rect = new Rect(0f, 0f, 1f, 1f);
                //枠の幅を変更する
                var waku4Rect = waku4.Find("Top").GetComponent<RectTransform>();
                waku4Rect.localScale = new Vector3(waku4Rect.localScale.x, waku4Rect.localScale.y, waku4Rect.localScale.z);
            }
      
        }
        else if(mode == SplitCameraMode.TwoCamera)
        {
            //侍とほかのプレイヤー
            if((SamuraiButton.SamuraiFlag == true)&&(MonkButton.MonkFlag == true))
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
            else if((SamuraiButton.SamuraiFlag == true)&&(OnmyojiButton.OnmyojiFlag == true))
            {
                //2,4P用のカメラは非表示
                player2Camera.gameObject.SetActive(false);
                player4Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player1Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
                player3Camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                //枠の幅を変更する
                var waku1Rect = waku1.Find("Right").GetComponent<RectTransform>();
                waku1Rect.localScale = new Vector3(waku1Rect.localScale.x / 2f, waku1Rect.localScale.y, waku1Rect.localScale.z);
                var waku3Rect = waku3.Find("Left").GetComponent<RectTransform>();
                waku3Rect.localScale = new Vector3(waku3Rect.localScale.x / 2f, waku3Rect.localScale.y, waku3Rect.localScale.z);
            }
            else if((SamuraiButton.SamuraiFlag == true)&&(ThiefButton.ThiefFlag == true))
            {
                //2,3P用のカメラは非表示
                player2Camera.gameObject.SetActive(false);
                player3Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player1Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
                player4Camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                //枠の幅を変更する
                var waku1Rect = waku1.Find("Right").GetComponent<RectTransform>();
                waku1Rect.localScale = new Vector3(waku1Rect.localScale.x / 2f, waku1Rect.localScale.y, waku1Rect.localScale.z);
                var waku4Rect = waku4.Find("Left").GetComponent<RectTransform>();
                waku4Rect.localScale = new Vector3(waku4Rect.localScale.x / 2f, waku4Rect.localScale.y, waku4Rect.localScale.z);
            }
            //僧侶とほかのプレイヤー
            if((MonkButton.MonkFlag == true)&&(SamuraiButton.SamuraiFlag == true))
            {
                //2,1P用のカメラは非表示
                player2Camera.gameObject.SetActive(false);
                player1Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player2Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
                player1Camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                //枠の幅を変更する
                var waku2Rect = waku2.Find("Right").GetComponent<RectTransform>();
                waku2Rect.localScale = new Vector3(waku2Rect.localScale.x / 2f, waku2Rect.localScale.y, waku2Rect.localScale.z);
                var waku1Rect = waku1.Find("Left").GetComponent<RectTransform>();
                waku1Rect.localScale = new Vector3(waku1Rect.localScale.x / 2f, waku1Rect.localScale.y, waku1Rect.localScale.z);
            }
            else if((MonkButton.MonkFlag == true)&&(OnmyojiButton.OnmyojiFlag == true))
            {
                //2,3P用のカメラは非表示
                player2Camera.gameObject.SetActive(false);
                player3Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player2Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
                player3Camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                //枠の幅を変更する
                var waku2Rect = waku2.Find("Right").GetComponent<RectTransform>();
                waku2Rect.localScale = new Vector3(waku2Rect.localScale.x / 2f, waku2Rect.localScale.y, waku2Rect.localScale.z);
                var waku3Rect = waku3.Find("Left").GetComponent<RectTransform>();
                waku3Rect.localScale = new Vector3(waku3Rect.localScale.x / 2f, waku3Rect.localScale.y, waku3Rect.localScale.z);
            }
            else if((MonkButton.MonkFlag == true)&&(ThiefButton.ThiefFlag == true))
            {
                //2,4P用のカメラは非表示
                player2Camera.gameObject.SetActive(false);
                player4Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player2Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
                player4Camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                //枠の幅を変更する
                var waku2Rect = waku2.Find("Right").GetComponent<RectTransform>();
                waku2Rect.localScale = new Vector3(waku2Rect.localScale.x / 2f, waku2Rect.localScale.y, waku2Rect.localScale.z);
                var waku4Rect = waku4.Find("Left").GetComponent<RectTransform>();
                waku4Rect.localScale = new Vector3(waku4Rect.localScale.x / 2f, waku4Rect.localScale.y, waku4Rect.localScale.z);
            }
            //陰陽師とその他プレイヤー
            if((OnmyojiButton.OnmyojiFlag == true)&&(SamuraiButton.SamuraiFlag == true))
            {
                //3,1P用のカメラは非表示
                player3Camera.gameObject.SetActive(false);
                player1Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player3Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
                player1Camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                //枠の幅を変更する
                var waku3Rect = waku3.Find("Right").GetComponent<RectTransform>();
                waku3Rect.localScale = new Vector3(waku3Rect.localScale.x / 2f, waku3Rect.localScale.y, waku3Rect.localScale.z);
                var waku1Rect = waku1.Find("Left").GetComponent<RectTransform>();
                waku1Rect.localScale = new Vector3(waku1Rect.localScale.x / 2f, waku1Rect.localScale.y, waku1Rect.localScale.z);
            }
            else if((OnmyojiButton.OnmyojiFlag == true)&&(MonkButton.MonkFlag == true))
            {
                //3,2P用のカメラは非表示
                player3Camera.gameObject.SetActive(false);
                player2Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player3Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
                player2Camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                //枠の幅を変更する
                var waku3Rect = waku3.Find("Right").GetComponent<RectTransform>();
                waku3Rect.localScale = new Vector3(waku3Rect.localScale.x / 2f, waku3Rect.localScale.y, waku3Rect.localScale.z);
                var waku2Rect = waku2.Find("Left").GetComponent<RectTransform>();
                waku2Rect.localScale = new Vector3(waku2Rect.localScale.x / 2f, waku2Rect.localScale.y, waku2Rect.localScale.z);
            }
            else if((OnmyojiButton.OnmyojiFlag == true)&&(ThiefButton.ThiefFlag == true))
            {
                //3,4P用のカメラは非表示
                player3Camera.gameObject.SetActive(false);
                player4Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player3Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
                player4Camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                //枠の幅を変更する
                var waku3Rect = waku3.Find("Right").GetComponent<RectTransform>();
                waku3Rect.localScale = new Vector3(waku3Rect.localScale.x / 2f, waku3Rect.localScale.y, waku3Rect.localScale.z);
                var waku4Rect = waku4.Find("Left").GetComponent<RectTransform>();
                waku4Rect.localScale = new Vector3(waku4Rect.localScale.x / 2f, waku4Rect.localScale.y, waku4Rect.localScale.z);
            }
            //盗賊とその他プレイヤー
            if((ThiefButton.ThiefFlag == true)&&(SamuraiButton.SamuraiFlag == true))
            {
                //4,1P用のカメラは非表示
                player4Camera.gameObject.SetActive(false);
                player1Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player4Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
                player1Camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                //枠の幅を変更する
                var waku4Rect = waku4.Find("Right").GetComponent<RectTransform>();
                waku4Rect.localScale = new Vector3(waku4Rect.localScale.x / 2f, waku4Rect.localScale.y, waku4Rect.localScale.z);
                var waku1Rect = waku1.Find("Left").GetComponent<RectTransform>();
                waku1Rect.localScale = new Vector3(waku1Rect.localScale.x / 2f, waku1Rect.localScale.y, waku1Rect.localScale.z);
            }
            else if((ThiefButton.ThiefFlag == true)&&(MonkButton.MonkFlag == true))
            {
                //4,2P用のカメラは非表示
                player4Camera.gameObject.SetActive(false);
                player2Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player4Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
                player2Camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                //枠の幅を変更する
                var waku4Rect = waku4.Find("Right").GetComponent<RectTransform>();
                waku4Rect.localScale = new Vector3(waku4Rect.localScale.x / 2f, waku4Rect.localScale.y, waku4Rect.localScale.z);
                var waku2Rect = waku2.Find("Left").GetComponent<RectTransform>();
                waku2Rect.localScale = new Vector3(waku2Rect.localScale.x / 2f, waku2Rect.localScale.y, waku2Rect.localScale.z);
            }
            else if((ThiefButton.ThiefFlag == true)&&(OnmyojiButton.OnmyojiFlag == true))
            {
                //4,3P用のカメラは非表示
                player4Camera.gameObject.SetActive(false);
                player3Camera.gameObject.SetActive(false);
                //カメラのRectを変更
                //Rectは第１引数がXの位置、第２引数がYの位置、第３引数が幅、第４引数が高さ
                player4Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
                player1Camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                //枠の幅を変更する
                var waku4Rect = waku4.Find("Right").GetComponent<RectTransform>();
                waku4Rect.localScale = new Vector3(waku4Rect.localScale.x / 2f, waku4Rect.localScale.y, waku4Rect.localScale.z);
                var waku3Rect = waku3.Find("Left").GetComponent<RectTransform>();
                waku3Rect.localScale = new Vector3(waku3Rect.localScale.x / 2f, waku3Rect.localScale.y, waku3Rect.localScale.z);
            }
        }
        //3人時のカメラ分割
        else if(mode == SplitCameraMode.ThreeCamera)
        {
            //侍とその他のプレイヤー
            if((SamuraiButton.SamuraiFlag == true)&&
               (MonkButton.MonkFlag == true)&&
               (OnmyojiButton.OnmyojiFlag == true))
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
    

        }
        //4人時のカメラ分割
        else if(mode == SplitCameraMode.FourCamera)
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

}
