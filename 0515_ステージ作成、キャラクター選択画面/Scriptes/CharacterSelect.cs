﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{

    Button samurai;
    Button onmyoji;
    Button nusutto;
    Button soryo;

    // Start is called before the first frame update
    void Start()
    {
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
        
    }
}
