using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreasureBox : MonoBehaviour
{

    //アイテム
    public GameObject item_key;
    public GameObject item_katana;
    public GameObject item_otakara;
    public GameObject item_gofu;
    public GameObject item_butsuzo;

    //アニメーター
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<animator>();

        eventsystem = GameObject.Find("EventSystem").GetComponent<eventsystem>();
        item_key = GameObject.Find("key");
        item_katana = GameObject.Find("sword");
        item_otakara = GameObject.Find("otakara");
        item_gofu = GameObject.Find("gofu");
        item_butsuzo = GameObject.Find("butsuzo");
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (animator.SetBool("touch",true))
            {
                animator.SetTrigger("Open");
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
                    case "katana":
                        item_katana.SetActive(false);
                        itemButton_key.SetActive(true);
                        break;
                    case "otakara":
                        item_otakara.SetActive(false);
                        itemButton_otakara.SetActive(true);
                        break;
                    case "gofu":
                        item_gofu.SetActive(false);
                        itemButton_gofu.SetActive(true);
                        break;
                    case "butsuzo":
                        item_butsuzo.SetActive(false);
                        itemButton_butsuzo.SetActive(true);
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
