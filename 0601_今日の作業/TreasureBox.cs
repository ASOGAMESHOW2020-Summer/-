using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreasureBox : MonoBehaviour
{

    //アイテム
    public GameObject item_key;
    public GameObject item_katana;
    public GameObject item_tabi;
    public GameObject item_sensu;
    public GameObject item_juzu;

    //アニメーター
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        eventsystem = GameObject.Find("EventSystem").GetComponent<eventsystem>();
        item_key = GameObject.Find("key");
        item_katana = GameObject.Find("sword");
        item_tabi = GameObject.Find("tabi");
        item_sensu = GameObject.Find("sensu");
        item_juzu = GameObject.Find("juzu");
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            animator = GetComponent<animator>();
            if (animator.SetBool("touch" == true))
            {
                selectedGameObject = hit.collider.gameObject;
                switch (selectedGameObject.name)
                {
                    case "TreasureBox":
                        iTween.MoveTo(item_key, iTween.Hash("z", 0, "time", 0.2, "islocal", true, "easeType", iTween.Hash));
                        break;
                    case "key":
                        item_key.SetActive(false);
                        itemButton_key.SetActive(true);
                        break;
                    case "sword":
                        item_katana.SetActive(false);
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
                        if (myItem == "key")
                        {
                            iTween.MoveTo(selectedGameObject.Find("exitDoor"), iTween.Hash("x", -40, "time", 0.4, "islocal", true));
                        }
                        break;

                }
            }
        }
       
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
