/*侍とエネミーの距離を計算して、UIを表示するスクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1DistanceEnemy : MonoBehaviour
{
    //自身との距離を計算するターゲットオブジェ
    [SerializeField]
    private Transform targetObj;
    //コライダーを考慮したオフセット値
    private float colliderOffset;
    [SerializeField]
    private GameObject FlashObj;
    [SerializeField]
    private Flash flash;

    void Start()
    {
         //colliderOffset = GetComponent<CharacterController>().radius + targetObj.GetComponent<CharacterController>().radius;
        colliderOffset = GetComponent<CharacterController>().radius + targetObj.GetComponent<CapsuleCollider>().radius;
        FlashObj = GameObject.Find("P1FlashImage");
        flash = FlashObj.GetComponent<Flash>();
    }

    void Update()
    {

        //距離を計算
        var distance = Vector3.Distance(transform.position, targetObj.position) - colliderOffset;

        if (distance < 5f)
        {

            flash.ImgFlash(true);
        }
        else if (distance > 5f)
        {
            flash.ImgFlash(false);
        }

    }
}