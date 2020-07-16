/*盗賊専用アイテムスクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Otakara : MonoBehaviour
{
    private bool OtakaraFlag = false;
    [SerializeField]
    private GameObject SkillImage;

    void Start()
    {
        OtakaraFlag = false;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Thief")
        {
            Destroy(gameObject);
            OtakaraFlag = true;
            GetOtakaraFlag();
            SkillImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    public bool GetOtakaraFlag()
    {
        return OtakaraFlag;
    }

}
