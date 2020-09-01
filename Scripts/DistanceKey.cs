using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceKey : MonoBehaviour
{
    //自身との距離を計算するターゲットオブジェ
    [SerializeField]
    private Transform samuraiObj;
    [SerializeField]
    private Transform monkObj;
    [SerializeField]
    private Transform onmyojiObj;
    [SerializeField]
    private Transform thiefObj;
    [SerializeField]
    private AudioSource audioSource;

    //コライダーを考慮したオフセット値
    private float SamuraicolliderOffset;
    private float MonkcolliderOffset;
    private float OnmyojicolliderOffset;
    private float ThiefcolliderOffset;


    void Start()
    {
        SamuraicolliderOffset = GetComponent<SphereCollider>().radius + samuraiObj.GetComponent<CharacterController>().radius;
        MonkcolliderOffset = GetComponent<SphereCollider>().radius + monkObj.GetComponent<CharacterController>().radius;
        OnmyojicolliderOffset = GetComponent<SphereCollider>().radius + onmyojiObj.GetComponent<CharacterController>().radius;
        ThiefcolliderOffset = GetComponent<SphereCollider>().radius + thiefObj.GetComponent<CharacterController>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        //距離を計算
        var Samuraidistance = Vector3.Distance(transform.position, samuraiObj.position) - SamuraicolliderOffset;
        var Monkdistance = Vector3.Distance(transform.position, monkObj.position) - MonkcolliderOffset;
        var Onmyojidistance = Vector3.Distance(transform.position, onmyojiObj.position) - OnmyojicolliderOffset;
        var Thiefdistance = Vector3.Distance(transform.position, thiefObj.position) - ThiefcolliderOffset;

        if (Samuraidistance < 5f)
        {
            audioSource.Play();
        }
        else if (Samuraidistance > 5f)
        {
            audioSource.Stop();
        }

        if(Monkdistance < 5f)
        {
            audioSource.Play();
        }
        else if(Monkdistance > 5f)
        {
            audioSource.Stop();
        }

        if(Onmyojidistance < 5f)
        {
            audioSource.Play();
        }
        else if(Onmyojidistance > 5f)
        {
            audioSource.Stop();
        }

        if(Thiefdistance > 5f)
        {
            audioSource.Play();
        }
        else if(Thiefdistance < 5f)
        {
            audioSource.Stop();
        }
    }
}
