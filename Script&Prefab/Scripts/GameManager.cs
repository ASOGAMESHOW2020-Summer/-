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
    //////鍵を格納する
    //[SerializeField]
    //private GameObject key;
    //[SerializeField]
    //private GameObject key2;
    //[SerializeField]
    //private GameObject key3;
    //[SerializeField]
    //private Key KeyScript;
    //[SerializeField]
    //private Key2 KeyScript2;
    //[SerializeField]
    //private Key3 KeyScript3;

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
        //key = GameObject.Find("鍵");
        //KeyScript = key.GetComponent<Key>();
        //key2 = GameObject.Find("鍵2");
        //KeyScript2 = key2.GetComponent<Key2>();
        //key3 = GameObject.Find("鍵3");
        //KeyScript3 = key3.GetComponent<Key3>();
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
        //GameClear();
    }

    void GameOver()
    {
        if (SamuraiState == SamuraiMoveScript.SamuraiState.Dead
        && (MonkState == MonkMoveScript.MonkState.Dead)
        && (OnmyojiState == OnmyojiMoveScript.OnmyojiState.Dead)
        && (ThiefState == ThiefMoveScript.ThiefState.Dead))
        {
            Debug.Log("ゲームオーバシーン移動");
            SceneManager.LoadScene("Test");
            
        }
    }

    //void GameClear()
    //{
    //    var key1 = KeyScript.GetKeyFlag();
    //    var key2 = KeyScript2.GetKeyFlag();
    //    var key3 = KeyScript3.GetKeyFlag();

    //    if ((key1 == true) && (key2 == true) && (key3 == true))
    //    {
    //        Debug.Log("ゲームクリアシーン移動");
    //        SceneManager.LoadScene("Test2");
    //    }
    //}
}
