using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        colliderOffset = GetComponent<CharacterController>().radius + targetObj.GetComponent<CharacterController>().radius;
        FlashObj = GameObject.Find("P1FlashImage");
        flash = FlashObj.GetComponent<Flash>();
    }

    // Update is called once per frame
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
