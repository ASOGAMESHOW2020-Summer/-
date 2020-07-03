/*僧侶専用アイテムスクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Butuzo : MonoBehaviour
{
    private bool ButuzoFlag = false;
    [SerializeField]
    private GameObject SkillImage;

    void Start()
    {
        ButuzoFlag = false;
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Monk")
        {
            Destroy(gameObject);
            ButuzoFlag = true;
            GetButuzoFlag();
            SkillImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    public bool GetButuzoFlag()
    {
        return ButuzoFlag;
    }
}
