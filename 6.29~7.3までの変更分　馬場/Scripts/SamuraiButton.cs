/*キャラ選択画面で侍を選んだ際の処理スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiButton : MonoBehaviour
{
    public enum SamuraiButtonState
    {
        Select,
        NoSelect
    };
    private SamuraiButtonState samuraiButtonState;
    private Animator animator;
    [SerializeField]
    private GameObject Samurai;
    [SerializeField]
    private GameObject CharacterButton;
    private int ConectCount = 0;

    public static bool SamuraiFlag = false;
    public static bool GamePad1 = false;
    public static bool GamePad2 = false;
    public static bool GamePad3 = false;
    public static bool GamePad4 = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        Samurai = GameObject.Find("侍");
        SamuraiFlag = false;
        ConectCount = 0;
        GamePad1 = false;
        GamePad2 = false;
        GamePad3 = false;
        GamePad4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(samuraiButtonState == SamuraiButtonState.Select)
        {
            if(Input.GetKeyDown("joystick button 0"))
            {
                //SamuraiFlag = true;
                //Samurai.SetActive(true);
            }
        }
        //ゲームパッドの誤って生成された以外の接続台数を調べる
        var GamePadNames = Input.GetJoystickNames();
        ConectCount = 0;
        //誤って生成されたものを省く処理
        for(int i = 0; i < GamePadNames.Length; i++)
        {
            if(GamePadNames[i] != "")
            {
                ConectCount++;
            }
        }
        //ゲームパッドの
        if(ConectCount == 1)
        {
            GamePad1 = true;
        }
        else if(ConectCount == 2)
        {
            GamePad2 = true;
        }
        else if(ConectCount == 3)
        {
            GamePad3 = true;
        }
        else if(ConectCount == 4)
        {
            GamePad4 = true;
        }
    }

    public void OnClick()
    {
        SamuraiFlag = true;
       // Samurai.SetActive(true);
    }
}
