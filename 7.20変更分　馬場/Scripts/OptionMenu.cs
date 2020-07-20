/*アイコンが一つしかない時のPanel表示設定スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject PanelObj;
    [SerializeField]
    private GameObject IconObj;
    [SerializeField]
    private MoveIcon moveicon;

    void Start()
    {
        PanelObj.SetActive(false);
        Debug.Log(IconObj.name);
        moveicon = IconObj.GetComponent<MoveIcon>();
    }

    void Update()
    {
        if(Input.GetButton("Start"))
        {
            PanelObj.SetActive(true);
            moveicon.enabled = false;
        }

        if(Input.GetButton("Back"))
        {
            PanelObj.SetActive(false);
            moveicon.enabled = true;
        }
    }
}
