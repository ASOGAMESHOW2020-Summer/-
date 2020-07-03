/*キャラ選択画面で僧侶が選ばれた際の処理スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkButton : MonoBehaviour
{
    public enum MonkButtonState
    {
        Select,
        NoSelect
    };
    private MonkButtonState monkButtonState;
    [SerializeField]
    private GameObject Monk;
    [SerializeField]
    private GameObject CharacterButton;
    private Animator animator;
    private int ConectCount = 0;

    public static bool MonkFlag = false;
    public static bool GamePad1 = false;
    public static bool GamePad2 = false;
    public static bool GamePad3 = false;
    public static bool GamePad4 = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        Monk = GameObject.Find("僧侶");
        MonkFlag = false;
        ConectCount = 0;
        GamePad1 = false;
        GamePad2 = false;
        GamePad3 = false;
        GamePad4 = false;
    }

    void Update()
    {
        if(monkButtonState == MonkButtonState.Select)
        {
            if(Input.GetKeyDown("joystick button 0"))
            {
                //MonkFlag = true;
                //Monk.SetActive(true);
            }
        }

        //ゲームパッドの誤って生成された以外の接続台数を調べる
        var GamePadNames = Input.GetJoystickNames();
        ConectCount = 0;
        //誤って生成されたものを省く処理
        for (int i = 0; i < GamePadNames.Length; i++)
        {
            if (GamePadNames[i] != "")
            {
                ConectCount++;
            }
        }
        //ゲームパッドの
        if (ConectCount == 1)
        {
            GamePad1 = true;
        }
        else if (ConectCount == 2)
        {
            GamePad2 = true;
        }
        else if (ConectCount == 3)
        {
            GamePad3 = true;
        }
        else if (ConectCount == 4)
        {
            GamePad4 = true;
        }
    }

    public void OnClick()
    {
        MonkFlag = true;
    }
}
