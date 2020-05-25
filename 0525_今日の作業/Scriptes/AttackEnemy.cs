using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            Debug.Log("当たり");
            coll.GetComponent<ModelMoveScript>().Damage(transform.root);
        }
    }
}
