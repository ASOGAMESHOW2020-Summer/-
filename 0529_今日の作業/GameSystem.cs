using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;


public class GameSystem : MonoBehaviour
{
    public GameOject mainCamera;　//カメラの定義
    public EventSystem eventsystem;//イベントシステム
    public static bool isClear = false;
    public static bool isFailed = false;

    //クリックで礼を飛ばす
    public Ray ray;
    public Ray rayItem;
    public RaycastHit hit;
    public GameObject selectedGameObject;

    //キャラクター
    public GameObject samurai;
    public GameObject onmyoji;
    public GameObject nusutto;
    public GameObject soryo;

    //アイテム
    public GameObject item_key;
    public GameObject item_sword;
    public GameObject item_tabi;
    public GameObject item_sensu;
    public GameObject item_juzu;

    /*--------------
      管理
    * ------------*/
    public string myItem;

    //アイテムボタン
    public GameObject itemButton_key;
    public GameObject itemButton_sword;
    public GameObject itemButton_tabi;
    public GameObject itemButton_sensu;
    public GameObject itemButton_juzu;


    // Start is called before the first frame update
    void Start()
    {
        eventsystem = GameObject.Find("EventSystem").GetComponent<eventsystem>();
        item_key = GameObject.Find("key");
        item_sword = GameObject.Find("sword");
        item_tabi = GameObject.Find("tabi");
        item_sensu = GameObject.Find("sensu");
        item_juzu = GameObject.Find("juzu");

        GameObject.Find("itemButto_key_plane").GetComponent<Renderer>().enabled = false;
        itemButton_key = GameObject.Find("itemButton_key");
        itemButton_key.SetActive(false);

        GameObject.Find("itemButto_sword_plane").GetComponent<Renderer>().enabled = false;
        itemButton_sword = GameObject.Find("itemButton_sword");
        itemButton_sword.SetActive(false);

        GameObject.Find("itemButto_tabi_plane").GetComponent<Renderer>().enabled = false;
        itemButton_tabi = GameObject.Find("itemButton_tabi");
        itemButton_tabi.SetActive(false);

        GameObject.Find("itemButto_sensu_plane").GetComponent<Renderer>().enabled = false;
        itemButton_sensu = GameObject.Find("itemButton_sensu");
        itemButton_sensu.SetActive(false);

        GameObject.Find("itemButto_juzu_plane").GetComponent<Renderer>().enabled = false;
        itemButton_juzu = GameObject.Find("itemButton_juzu");
        itemButton_juzu.SetActive(false);
        myItem = "noitem";

        switch(PlayerPrefs.GetInt("chara"))
        {
            case 1:
                Player1.SetActive(true);
                break;

            case 2:
                Player2.SetActive(true);
                break;
            case 3:
                Player3.SetActive(true);
            case 4:
                Player4.SetActive(true);
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //画面クリック処理
        if(Input.GetMouseButtonUp(0))//左クリック
        {
            if(eventsystem.currentSelectedGameObject==null)//UI以外を触った
            {
                searchRoom();//3Dオブジェクトをクリックした時の処理
            }
            else
            {
                //UIをさわった
                switch(eventsystem.currentSelectedGameObject.name)
                {
                    case "turnBtn":
                        turnL();
                        break;
                }
            }
        }
    }
    
    public void searchTreasureBox()
    {
        selectedGameObject = null;
        ray = mainCamera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit,10000000,1<<8))
        {
            selectedGameObject = hit.collider.gameObject;
            switch(selectedGameObject.name)
            {
                case "TreasureBox":
                    iTween.MoveTo(item_key, iTween.Hash("z", 0, "time", 0.2, "islocal", true, "easeType", iTween.Hash));
                    break;
                case "key":
                    item_key.SetActive(false);
                    itemButton_key.SetActive(true);
                    break;
                case "sword":
                    item_sword.SetActive(false);
                    itemButton_key.SetActive(true);
                    break;
                case "tabi":
                    item_tabi.SetActive(false);
                    itemButton_tabi.SetActive(true);
                    break;
                case "sensu":
                    item_sensu.SetActive(false);
                    itemButton_sensu.SetActive(true);
                    break;
                case "juzu":
                    item_juzu.SetActive(false);
                    itemButton_juzu.SetActive(true);
                    break;
                case "exitDoor":
                    if(myItem=="key")
                    {
                        iTween.MoveTo(selectedGameObject.Find("exitDoor"), iTween.Hash("x", -40, "time", 0.4, "islocal", true));
                    }
                    break;

            }
        }
        rayItem = GameObject.Find("ItemListCamera").getComponent<mainCamera>().Scre;
        if(Physics.Raycast(rayItem,out hit,10000000,1<<9))
        {
            selectedGameObject = hit.collider.gameObject;
            switch(selectedGameObject.name)
            {
                case "itemButton_key_plane":
                    if(myItem == "key")
                    {
                        GameObject.Find("itemButton_key_plane").GetComponent<Renderer>();
                        myItem = "noitem";
                    }
                    else
                    {
                        GameObject.Find("itemButton_key_plane").GetComponent<Renderer>();
                        myItem = "key";
                    }
                    break;
            }
        }
    }
    
}
