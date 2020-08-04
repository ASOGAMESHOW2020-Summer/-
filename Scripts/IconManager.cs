using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{
    //アイコンのゲームオブジェクト
    [SerializeField]
    private GameObject Icon1;
    [SerializeField]
    private GameObject Icon2;
    [SerializeField]
    private GameObject Icon3;
    [SerializeField]
    private GameObject Icon4;
    // Start is called before the first frame update
    void Start()
    {
        //最初に全アイコンを非アクティブ化
        Icon1.SetActive(false);
        Icon2.SetActive(false);
        Icon3.SetActive(false);
        Icon4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GamePadConnectNum.pad1 == true)
        {
            Icon1.SetActive(true);
        }
        else if(GamePadConnectNum.pad2 == true)
        {
            Icon2.SetActive(true);
        }
        else if(GamePadConnectNum.pad3 == true)
        {
            Icon3.SetActive(true);
        }
        else if(GamePadConnectNum.pad4 == true)
        {
            Icon4.SetActive(true);
        }
    }
}
