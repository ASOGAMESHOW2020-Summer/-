using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayClear : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        GameClear();
    }

    
    void OnTriggerEnter(Collider coll)
    {

        if (coll.tag == "Samurai")
        {
           
            Player1Escape = true;
            Destroy(Player1);
        }
        else if (coll.tag == "Monk")
        {
            
             Player2Escape = true;
             Destroy(Player2);
            
        }
        else if (coll.tag == "Onmyoji")
        {
            Player3Escape = true;
            Destroy(Player3);
        }
        else if (coll.tag == "Thief")
        {
            
            Player4Escape = true;
            Destroy(Player4);
            
        }
    }
    void GameClear()
    {
        if ((Player1Escape == true) && (Player2Escape == true)
        && (Player3Escape == true) && (Player4Escape == true))
        {
            Debug.Log("GameClear");
            SceneManager.LoadScene("Clear");
        }
    }
}
