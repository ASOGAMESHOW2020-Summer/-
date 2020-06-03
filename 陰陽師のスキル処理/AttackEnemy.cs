﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Samurai")
        {
            Debug.Log("侍当たり");
            coll.GetComponent<SamuraiMoveScript>().LifeDamage(1);
            coll.GetComponent<SamuraiMoveScript>().Damage(transform.root);
        }
        else if(coll.tag == "Monk")
        {
            Debug.Log("僧侶当たり");
            coll.GetComponent<MonkMoveScript>().LifeDamage(1);
            coll.GetComponent<MonkMoveScript>().Damage(transform.root);
        }
        else if(coll.tag == "Onmyoji")
        {
            if (coll.GetComponent<OnmyojiMoveScript>().GetSkillFlag() == true)
            {
                //確率今は50％に設定
                if (coll.GetComponent<Probability>().Probailitys(50))
                {
                    Debug.Log("陰陽師当たり(Skillあり)");
                    coll.GetComponent<OnmyojiMoveScript>().LifeDamage(1);
                    coll.GetComponent<OnmyojiMoveScript>().Damage(transform.root);
                    coll.GetComponent<OnmyojiMoveScript>().SetSkillFlag(false);
                    Debug.Log("スキルオフ");
                }
            }
            else
            {
                Debug.Log("陰陽師当たり(Skillなし）");
                coll.GetComponent<OnmyojiMoveScript>().LifeDamage(1);
                coll.GetComponent<OnmyojiMoveScript>().Damage(transform.root);
            }
        }
        else if(coll.tag == "Thief")
        {
            Debug.Log("盗賊当たり");
            coll.GetComponent<ThiefMoveScript>().LifeDamage(1);
            coll.GetComponent<ThiefMoveScript>().Damage(transform.root);
        }
    }
}

