/*陰陽師専用アイテムスクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gofu : MonoBehaviour
{
    private bool GofuFlag = false;
    [SerializeField]
    private GameObject SkillImage;

    void Start()
    {
        GofuFlag = false;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Onmyoji")
        {
            Destroy(gameObject);
            GofuFlag = true;
            GetGofuFlag();
            SkillImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    public bool GetGofuFlag()
    {
        return GofuFlag;
    }
}
