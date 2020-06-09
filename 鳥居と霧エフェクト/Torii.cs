using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Torii : MonoBehaviour
{
    ////鍵を格納する
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private GameObject key2;
    [SerializeField]
    private GameObject key3;
    [SerializeField]
    private Key KeyScript;
    [SerializeField]
    private Key2 KeyScript2;
    [SerializeField]
    private Key3 KeyScript3;
    //脱出フラグ
    bool Player1Escape = false;
    bool Player2Escape = false;
    bool Player3Escape = false;
    bool Player4Escape = false;
    //プレイヤーオブジェ
    [SerializeField]
    private GameObject Player1;
    [SerializeField]
    GameObject Player2;
    [SerializeField]
    GameObject Player3;
    [SerializeField]
    GameObject Player4;
    //エフェクトオブジェクト
    [SerializeField]
    private GameObject skillEffect;
    [SerializeField]
    private ParticleSystem skillParticle;

    void Start()
    {
        Debug.Log("鳥居出現");
        key = GameObject.Find("鍵");
        KeyScript = key.GetComponent<Key>();
        key2 = GameObject.Find("鍵2");
        KeyScript2 = key2.GetComponent<Key2>();
        key3 = GameObject.Find("鍵3");
        KeyScript3 = key3.GetComponent<Key3>();
        //プレイヤーオブジェ
        Player1 = GameObject.Find("侍");
        Player2 = GameObject.Find("僧侶");
        Player3 = GameObject.Find("陰陽師");
        Player4 = GameObject.Find("盗賊");

        //フラグの初期化
        Player1Escape = false;
        Player2Escape = false;
        Player3Escape = false;
        Player4Escape = false;
    }

    void Update()
    {
        GameClear();
    }

    void GameClear()
    {
        if((Player1Escape == true)&&(Player2Escape == true)
        && (Player3Escape == true)&&(Player4Escape == true))
        {
            Debug.Log("GameClear");
            SceneManager.LoadScene("Test2");
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        var key1 = KeyScript.GetKeyFlag();
        var key2 = KeyScript2.GetKeyFlag();
        var key3 = KeyScript3.GetKeyFlag();

        if (coll.tag == "Samurai")
        {
            if((key1 == true) && (key2 == true) && (key3 == true))
            {
                Player1Escape = true;
                Destroy(Player1);
            }
        }
        else if (coll.tag == "Monk")
        {
            if ((key1 == true) && (key2 == true) && (key3 == true))
            {
                Player2Escape = true;
                Destroy(Player2);
            }
        }
        else if (coll.tag == "Onmyoji")
        {
            if ((key1 == true) && (key2 == true) && (key3 == true))
            {
                Player3Escape = true;
                Destroy(Player3);
            }
        }
        else if (coll.tag == "Thief")
        {
            if ((key1 == true) && (key2 == true) && (key3 == true))
            {
                Player4Escape = true;
                Destroy(Player4);
            }
        }
    }
}
