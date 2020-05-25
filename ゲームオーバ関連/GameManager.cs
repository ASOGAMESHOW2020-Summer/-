﻿using System.Collections;
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

    // Start is called before the first frame update
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
        Debug.Log("とんでもねぇ待ってたんだ");
    }

    // Update is called once per frame
    void Update()
    {
       NextScene();
    }

    void NextScene()
    {
        //プレイヤー（侍）の状態を取得
        SamuraiMoveScript.SamuraiState SamuraiState = SamuraiScript.GetState();
        //プレイヤー（僧侶）の状態を取得
        MonkMoveScript.MonkState MonkState = MonkScript.GetState();
        //プレイヤー（陰陽師）の状態を取得
        OnmyojiMoveScript.OnmyojiState OnmyojiState = OnmyojiScript.GetState();
        //プレイヤー（盗賊）の状態を取得
        ThiefMoveScript.ThiefState ThiefState = ThiefScript.GetState();

        if (SamuraiState == SamuraiMoveScript.SamuraiState.Dead
        && (MonkState == MonkMoveScript.MonkState.Dead)
        && (OnmyojiState == OnmyojiMoveScript.OnmyojiState.Dead)
        && (ThiefState == ThiefMoveScript.ThiefState.Dead))
        {
          SceneManager.LoadScene("Test");
            Debug.Log("シーン移動");
        }
    }
}
