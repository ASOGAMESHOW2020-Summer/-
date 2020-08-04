/*ゲーム管理スクリプト（ゲームオーバー処理）*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //プレイヤー（侍）を格納する
    [SerializeField]
    private GameObject Samurai;
    [SerializeField]
    private SamuraiMoveScript SamuraiScript;
    //プレイヤー（僧侶）を格納する
    [SerializeField]
    private GameObject Monk;
    [SerializeField]
    private MonkMoveScript MonkScript;
    //プレイヤー（陰陽師）を格納する
    [SerializeField]
    private GameObject Onmyoji;
    [SerializeField]
    private OnmyojiMoveScript OnmyojiScript;
    //プレイヤー（盗賊）を格納する
    [SerializeField]
    private GameObject Thief;
    [SerializeField]
    private ThiefMoveScript ThiefScript;

    SamuraiMoveScript.SamuraiState SamuraiState;
    MonkMoveScript.MonkState MonkState;
    OnmyojiMoveScript.OnmyojiState OnmyojiState;
    ThiefMoveScript.ThiefState ThiefState;

    void Start()
    {   
        Samurai = GameObject.Find("侍");
        SamuraiScript = Samurai.GetComponent<SamuraiMoveScript>();
        Monk = GameObject.Find("僧侶");
        MonkScript = Monk.GetComponent<MonkMoveScript>();
        Onmyoji = GameObject.Find("陰陽師");
        OnmyojiScript = Onmyoji.GetComponent<OnmyojiMoveScript>();
        Thief = GameObject.Find("盗賊");
        ThiefScript = Thief.GetComponent<ThiefMoveScript>();
    }

    void Update()
    {
        //プレイヤー（侍）の状態を取得
        SamuraiState = SamuraiScript.GetState();
        //プレイヤー（僧侶）の状態を取得
        MonkState = MonkScript.GetState();
        //プレイヤー（陰陽師）の状態を取得
        OnmyojiState = OnmyojiScript.GetState();
        //プレイヤー（盗賊）の状態を取得
        ThiefState = ThiefScript.GetState();
        GameOver();
    }

    void GameOver()
    {
        if (SamuraiState == SamuraiMoveScript.SamuraiState.Dead
        && (MonkState == MonkMoveScript.MonkState.Dead)
        && (OnmyojiState == OnmyojiMoveScript.OnmyojiState.Dead)
        && (ThiefState == ThiefMoveScript.ThiefState.Dead))
        {
            Debug.Log("ゲームオーバシーン移動");
            SceneManager.LoadScene("Failed");
            
        }
    }

}
