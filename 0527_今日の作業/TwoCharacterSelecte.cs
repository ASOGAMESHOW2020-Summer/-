﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoCharacterSelecte : MonoBehaviour
{
    Button samurai;
    Button onmyoji;
    Button nusutto;
    Button soryo;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("chara");
        //ボタンコンポーネントの取得
        samurai = GameObject.Find("/Canvas/CharacterButton").GetComponent<Button>();
        onmyoji = GameObject.Find("/Canvas/CharacterButton1").GetComponent<Button>();
        nusutto = GameObject.Find("/Canvas/CharacterButton2").GetComponent<Button>();
        soryo = GameObject.Find("/Canvas/CharacterButton3").GetComponent<Button>();

        //最初に選択状態にしたいキャラクター
        samurai.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player1Selecte==false&&Player2Select==false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                samurai.Select();
                PlayerPrefs.SetInt("chara", 1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                onmyoji.Select();
                playerPrefs.SetInt("chara", 2);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                nusutto.Select();
                playerPrefs.SetInt("chara", 3);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                soryo.Select();
                playerPrefs.SetInt("chara", 4);
            }
        }
        else if(Player1Select==true&&(Player2Select==false))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                samurai.Select();
                PlayerPrefs.SetInt("chara", 1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                onmyoji.Select();
                playerPrefs.SetInt("chara", 2);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                nusutto.Select();
                playerPrefs.SetInt("chara", 3);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                soryo.Select();
                playerPrefs.SetInt("chara", 4);
            }
        }
    }
}
