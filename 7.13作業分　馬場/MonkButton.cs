/*キャラ選択画面で僧侶が選ばれた際の処理スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    [SerializeField]
    private Text text;

    public static bool MonkFlag = false;
    public static bool GamePad1 = false;
    public static bool GamePad2 = false;
    public static bool GamePad3 = false;
    public static bool GamePad4 = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        Monk = GameObject.Find("僧侶");
        text.GetComponent<Text>();
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
        ////ゲームパッドの
        //if (ConectCount == 1)
        //{
        //    GamePad1 = true;
        //}
        //else if (ConectCount == 2)
        //{
        //    GamePad2 = true;
        //}
        //else if (ConectCount == 3)
        //{
        //    GamePad3 = true;
        //}
        //else if (ConectCount == 4)
        //{
        //    GamePad4 = true;
        //}
    }

    public void OnClick()
    {
        MonkFlag = true;
    }

    //　マウスアイコンが自分のアイコン上に入った時
    void OnTriggerEnter2D(Collider2D col)
    {
        CheckEvent(col);
    }

    //　マウスアイコンが自分のアイコン上にいる間
    void OnTriggerStay2D(Collider2D col)
    {
        CheckEvent(col);
    }

    void CheckEvent(Collider2D col)
    {
        //　アイコンを検知する
        if (col.tag == "Icon")
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                //　このUIをフォーカスする
                EventSystem.current.SetSelectedGameObject(gameObject);

            }
            if (Input.GetButtonDown("Submit"))
            {
                text.text = "選択:1P";
                OnClick();
            }
        }
        else if (col.tag == "Icon2")
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                //　このUIをフォーカスする
                EventSystem.current.SetSelectedGameObject(gameObject);

            }
            if (Input.GetButtonDown("Submit2"))
            {
                text.text = "選択:2P";
                OnClick();
            }
        }
        else if (col.tag == "Icon3")
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                //　このUIをフォーカスする
                EventSystem.current.SetSelectedGameObject(gameObject);

            }
            if (Input.GetButtonDown("Submit3"))
            {
                text.text = "選択:3P";
                OnClick();
            }
        }
        else if (col.tag == "Icon4")
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                //　このUIをフォーカスする
                EventSystem.current.SetSelectedGameObject(gameObject);

            }
            if (Input.GetButtonDown("Submit4"))
            {
                text.text = "選択:4P";
                OnClick();
            }
        }
    }

    //　マウスアイコンが自分のアイコン上から出て行った時
    void OnTriggerExit2D(Collider2D col)
    {

        if ((col.tag == "Icon") || (col.tag == "Icon2") ||
            (col.tag == "Icon3") || (col.tag == "Icon4"))
        {
            //　フォーカスを解除する
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}

