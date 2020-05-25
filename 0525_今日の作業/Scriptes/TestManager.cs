using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystem;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    public EventSystem eventSystem;

    //ray関係
    public Ray ray;
    public RaycastHit hit;
    public GameObject selectedGameObject;

    //controllers
    public ItemListController itemListController;
    public ItemDetailController itemDetailController;
    public EventController eventController;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = selectedGameObject.Find("EventSystem").GetComponent<eventSystem>();

        //アイテムリストの操作
        itemListController = itemListController.getInstance();
        //アイテム詳細画面の操作+アイテムごとの処理
        itemDetailController = itemDetailController.getInstance();
        itemDetailController.createItemInstances();
        //ゲーム画面でのイベント操作+イベント処理
        eventController = eventController.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            selectedGameObject = eventSystem.currentSelectedGameObject;
            if(selectedGameObject == null)
            {
                searchRoom();
            }
            else
            {
                switch(selectedGameObject.tag)
                {
                    case "ItemListButton":
                        itemListController.click(selectedGameObject);
                        break;
                    case "ItemDetail":
                        itemDetailController.main(selectedGameObject);
                        break;

                }
            }
        }

    }
    public void searchRoom()
    {
        selectedGameObject = null;
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit,10000000,1<<9|10))
        {
            selectedGameObject = hit.collider.gameObject;
            Debug.Log("selected object is" + selectedGameObject.name);

            switch(selectedGameObject.layer)
            {
                case 9:
                    eventController.main(selectedGameObject);
                    break;

                case 10:
                    itemListController.add(selectedGameObject);
                    Destroy(selectedGameObject);
                    break;
            }
        }
    }

}
