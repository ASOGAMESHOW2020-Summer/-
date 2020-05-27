using System.Collections;
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
            Debug.Log("陰陽師当たり");
            coll.GetComponent<OnmyojiMoveScript>().LifeDamage(1);
            coll.GetComponent<OnmyojiMoveScript>().Damage(transform.root);
        }
        else if(coll.tag == "Thief")
        {
            Debug.Log("盗賊当たり");
            coll.GetComponent<ThiefMoveScript>().LifeDamage(1);
            coll.GetComponent<ThiefMoveScript>().Damage(transform.root);
        }
    }
}

