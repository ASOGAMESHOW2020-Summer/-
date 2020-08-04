﻿/*エネミーの攻撃処理*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    //Audio
    AudioSource audioSource;
    [SerializeField]
    private AudioClip SamuraiSkillSe;
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Samurai")
        {
            if (SamuraiMoveScript.hp > 0)
            {
                if (SamuraiMoveScript.YoroiFlag == true)
                {
                    audioSource.PlayOneShot(SamuraiSkillSe);
                    Debug.Log("防御");
                    SamuraiMoveScript.YoroiFlag = false;
                }
                Debug.Log("侍当たり");
                coll.GetComponent<SamuraiMoveScript>().LifeDamage(1);
                coll.GetComponent<SamuraiMoveScript>().Damage(transform.root, coll.ClosestPoint(transform.position));
            }
            Debug.Log("silyuurilyou");

        }
        else if (coll.tag == "Monk")
        {
            if (MonkMoveScript.hp > 0)
            {
                Debug.Log("僧侶当たり");
                coll.GetComponent<MonkMoveScript>().LifeDamage(1);
                coll.GetComponent<MonkMoveScript>().Damage(transform.root, coll.ClosestPoint(transform.position));
            }
        }
        else if (coll.tag == "Onmyoji")
        {
            if (coll.GetComponent<OnmyojiMoveScript>().GetSkillFlag() == true)
            {
                //確率今は50％に設定
                if (coll.GetComponent<Probability>().Probailitys(50))
                {
                    Debug.Log("陰陽師当たり(Skillあり)");
                    coll.GetComponent<OnmyojiMoveScript>().LifeDamage(1);
                    coll.GetComponent<OnmyojiMoveScript>().Damage(transform.root, coll.ClosestPoint(transform.position));
                    coll.GetComponent<OnmyojiMoveScript>().SetSkillFlag(false);
                    Debug.Log("スキルオフ");
                }
            }
            else
            {
                Debug.Log("陰陽師当たり(Skillなし）");
                coll.GetComponent<OnmyojiMoveScript>().LifeDamage(1);
                coll.GetComponent<OnmyojiMoveScript>().Damage(transform.root, coll.ClosestPoint(transform.position));
            }
        }
        else if (coll.tag == "Thief")
        {
            Debug.Log("盗賊当たり");
            coll.GetComponent<ThiefMoveScript>().LifeDamage(1);
            coll.GetComponent<ThiefMoveScript>().Damage(transform.root, coll.ClosestPoint(transform.position));
        }
    }
}

