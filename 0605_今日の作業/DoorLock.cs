using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystem;
using UnityEngine.UI;

public class DoorLock : MonoBehaviour
{
    //GameObjects
    public GameObject door;

    //Controllers
    public ItemListController itemListController;

    //Animator
    private Animator animator;
    public DoorLock()
    {
        door = GameObject.Find("ExitDoor");

        itemListController = ItemListController.getInstance();

        animator = GetComponent<animator>();
    }

    public void main()
    {
        string selectedItemName = itemListController.getSelectedItemName();
        if(selectedItemName == "Key")
        {
            //ドアを開ける
            iTween.RotateTo(door, iTween.Hash("time", "3f", "z", 90f));

            //鍵を消去
            itemListController.removeSelectedItem();
        }
        else
        {
            iTween.ShakeRotation(door, iTween.Hash("time", 0.3f, "z", 2f));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
