using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("当たり");
            col.GetComponent<CharacterMoveScript>().LifeDamage(1);
            col.GetComponent<CharacterMoveScript>().Damage(transform.root);
        }
    }
}

