/*侍の攻撃処理*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttarkSowrd : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Enemy")
        {
            Debug.Log("天網恢恢");
            coll.GetComponent<EnemyMoveScript>().Damage(coll.ClosestPointOnBounds(transform.position));
        }
    }
}
