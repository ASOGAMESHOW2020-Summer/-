using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoCharacterSelecte : MonoBehaviour
{
    
    //侍フラグ
    private bool SamuraiFlag;
    //陰陽師フラグ
    private bool OnmyojiFlag;
    //僧侶フラグ
    private bool MonkFlag;
    //盗人フラグ
    private bool ThiefFlag;

    //ボタンスクリプト
    //侍
    private SamuraiButton samuraiButton;
    //陰陽師
    private OnmyojiButton onmyojiButton;
    //僧侶
    private MonkButton monkButton;
    //盗人
    private ThiefButton thiefButton;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("chara");
        //ボタンコンポーネントの取得
        samuraiButton = GameObject.Find("/Canvas/CharacterButton").GetComponent<SamuraiButton>();
        onmyojiButton = GameObject.Find("/Canvas/CharacterButton1").GetComponent<OnmyojiButton>();
        thiefButton = GameObject.Find("/Canvas/CharacterButton2").GetComponent<ThiefButton>();
        monkButton = GameObject.Find("/Canvas/CharacterButton3").GetComponent<MonkButton>();
;
        //最初に選択状態にしたいキャラクター
        samuraiButton.Select();
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
