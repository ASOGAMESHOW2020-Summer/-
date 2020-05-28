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
    //テスト用UI
    [SerializeField]
    private Text distanceUI;
    [SerializeField]
    private GameObject FlashObj;
    [SerializeField]
    private Flash flash;
    private RectTransform FlashImage;
    public float w, h;//変更したいサイズ
    public float x, y, z;//変更したい座標

    void Start()
    {
        colliderOffset = GetComponent<CharacterController>().radius + targetObj.GetComponent<CharacterController>().radius;
        FlashObj = GameObject.Find("P1FlashImage");
        flash = FlashObj.GetComponent<Flash>();
        FlashImage = GameObject.Find("P1FlashImage").GetComponent<RectTransform>();
        FlashImage.sizeDelta = new Vector2(w, h);
        FlashImage.localPosition = new Vector3(x, y, z);
    }

    void Update()
    {
        //距離を計算
       var distance = Vector3.Distance(transform.position, targetObj.position) - colliderOffset;
        
        if(Vector3.Distance(transform.position, targetObj.position) - colliderOffset < 5f)
        {
            flash.ImgFlash(true);
        }
        else if(Vector3.Distance(transform.position, targetObj.position) - colliderOffset > 5f)
        {
            flash.ImgFlash(false);
        }
        if (distanceUI != null)
        {
            distanceUI.text = distance.ToString("0.00m");
        }
        else
        {
            Debug.Log(distance.ToString("0.00m"));
        }
    }
}