/*侍専用アイテムスクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Katana : MonoBehaviour
{
    private bool KatanaFlag = false;
    [SerializeField]
    private GameObject SkillImage;

    void Start()
    {
        //刀フラグ初期化
        KatanaFlag = false;
    }

    void OnTriggerEnter(Collider coll)
    {
        Destroy(gameObject);
        KatanaFlag = true;
        GetKatanaFlag();
        SkillImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    
    public bool GetKatanaFlag()
    {
        return KatanaFlag;
    }

    public void SetKatanaFlag(bool flag)
    {
        flag = KatanaFlag;
    }
}
