/*キャラ選択画面で盗賊を選んだ際の処理スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThiefButton : MonoBehaviour
{
    private Animator animator;
    public static bool ThiefFlag = false;
    [SerializeField]
    private Text text;
    public static bool TextFlag;

    void Start()
    {
        animator = GetComponent<Animator>();
        text.GetComponent<Text>();
        ThiefFlag = false;
        TextFlag = false;
    }

    void Update()
    {
    }

    public void OnClick()
    {
        ThiefFlag = true;
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
                TextFlag = true;
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

