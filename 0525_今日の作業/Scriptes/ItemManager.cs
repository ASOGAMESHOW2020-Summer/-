using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //アイテムデータベース
    [SerializeField]
    private ItemDataBase itemDataBase;
    //アイテム数管理
    private Dictionary<Item, int> numOfItem = new Dictionary<Item, int>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<itemDataBase.GetItemLists().Count;i++)
        {
            //アイテム数を適当に設定
            numOfItem.Add(itemDataBase.GetItemLists() [i], i);
            //確認のためデータ出力
            Debug.Log(itemDataBase.GetItemLists()[i].GetItemName() + ":" + itemDataBase.GetItemLists()[i].GetInformation());

        }

        Debug.Log(GetItem("鍵").GetInformation());
        Debug.Log(numOfItem[GetItem("刀")]);
    }

    //名前でアイテム取得
    public ItemManager GetItem(string searchName)
    {
        return itemDataBase.getItemLists().Find(itemName.GetItemName() == searchName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
