﻿/*僧侶専用アイテムスクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Butuzo : MonoBehaviour
{
    private bool ButuzoFlag = false;
    [SerializeField]
    private GameObject SkillImage;
    [Header("入力した値の間のランダム値をX座標にする")]
    [SerializeField]
    float Xmin, Xmax;
    [Header("入力した値の間のランダム値をY座標にする")]
    [SerializeField]
    float Ymin, Ymax;
    [Header("入力した値の間のランダム値をZ座標にする")]
    [SerializeField]
    float Zmin, Zmax;

    void Start()
    {
        ButuzoFlag = false;
        //座標設定
        var x = Random.Range(Xmin, Xmax);
        var y = Random.Range(Ymin, Ymax);
        var z = Random.Range(Zmin, Zmax);
        var randomPosition = new Vector3(x, y, z);
        transform.position = randomPosition;
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
