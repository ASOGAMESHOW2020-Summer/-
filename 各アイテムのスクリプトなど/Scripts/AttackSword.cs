using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSword : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            Debug.Log("天網恢恢");
            coll.GetComponent<EnemyMoveScript>().Damage(coll.ClosestPointOnBounds(transform.position));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
