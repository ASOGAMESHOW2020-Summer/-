using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceEnemy : MonoBehaviour
{
    //自身との距離を計算するターゲットオブジェ
    [SerializeField]
    private Transform targetObj;
    //コライダーを考慮したオフセット値
    private float colliderOffset;
    //テスト用UI
    [SerializeField]
    private Text distanceUI;
    [SerializeField]
    private Flash flash;
    [SerializeField]
    private GameObject obj;

   

    void Start()
    {
        colliderOffset = GetComponent<CharacterController>().radius + targetObj.GetComponent<CharacterController>().radius;
        obj = GameObject.Find("FlashImage");
        flash = obj.GetComponent<Flash>();
    }

    void Update()
    {
        //距離を計算
       // var distance = Vector3.Distance(transform.position, targetObj.position) - colliderOffset;
        
        if(Vector3.Distance(transform.position, targetObj.position) - colliderOffset < 5f)
        {
            flash.ImgFlash(true);
        }
        else if(Vector3.Distance(transform.position, targetObj.position) - colliderOffset > 5f)
        {
            flash.ImgFlash(false);
        }
        //if(distanceUI != null)
        //{
        //    distanceUI.text = distance.ToString("0.00m");
        //}
        //else
        //{
        //    Debug.Log(distance.ToString("0.00m"));
        //}
    }
}