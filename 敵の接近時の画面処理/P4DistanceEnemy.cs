using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P4DistanceEnemy : MonoBehaviour
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
        colliderOffset = GetComponent<CharacterController>().radius + targetObj.GetComponent<CharacterController>().radius;
        FlashObj = GameObject.Find("P4FlashImage");
        flash = FlashObj.GetComponent<Flash>();
    }

    void Update()
    {

        //距離を計算
        var distance = Vector3.Distance(transform.position, targetObj.position) - colliderOffset;

        if (Vector3.Distance(transform.position, targetObj.position) - colliderOffset < 5f)
        {
            flash.ImgFlash(true);
        }
        else if (Vector3.Distance(transform.position, targetObj.position) - colliderOffset > 5f)
        {
            flash.ImgFlash(false);
        }
    }
}