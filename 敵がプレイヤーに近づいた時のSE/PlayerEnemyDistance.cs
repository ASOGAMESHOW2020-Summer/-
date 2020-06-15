using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyDistance : MonoBehaviour
{
    //自身との距離を計算するターゲットオブジェ
    [SerializeField]
    private Transform targetObj;
    [SerializeField]
    private Transform targetObj2;
    [SerializeField]
    private Transform targetObj3;
    [SerializeField]
    private Transform targetObj4;
    //コライダーを考慮したオフセット値
    private float colliderOffset;
    private float colliderOffset2;
    private float colliderOffset3;
    private float colliderOffset4;
    AudioSource audioSource;

    void Start()
    {
        colliderOffset = GetComponent<CharacterController>().radius + targetObj.GetComponent<CharacterController>().radius;
        colliderOffset2 = GetComponent<CharacterController>().radius + targetObj2.GetComponent<CharacterController>().radius;
        colliderOffset3 = GetComponent<CharacterController>().radius + targetObj3.GetComponent<CharacterController>().radius;
        colliderOffset4 = GetComponent<CharacterController>().radius + targetObj4.GetComponent<CharacterController>().radius;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //距離を計算
        var distance = Vector3.Distance(transform.position, targetObj.position) - colliderOffset;
        var distance2 = Vector3.Distance(transform.position, targetObj2.position) - colliderOffset2;
        var distance3 = Vector3.Distance(transform.position, targetObj3.position) - colliderOffset3;
        var distance4 = Vector3.Distance(transform.position, targetObj4.position) - colliderOffset4;

        if (distance < 5f)
        {
            audioSource.Play();
        }
        else if (distance > 5f)
        {
            //audioSource.Stop();
        }

        if (distance2 < 5f)
        {
             //audioSource.Play();
        }
        else if (distance2 > 5f)
        {
           // audioSource.Stop();
        }

        if (distance3 < 5f)
        {
            // audioSource.Play();
        }
        else if (distance3 > 5f)
        {
           // audioSource.Stop();
        }

        if (distance4 < 5f)
        {
             //audioSource.Play();
        }
        else if (distance4 > 5f)
        {
           // audioSource.Stop();
        }
    }
}