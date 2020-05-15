using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter : MonoBehaviour
{
    private EnemyMoveScript Enemymove;
    
    void Start()
    {
        Enemymove = GetComponentInParent<EnemyMoveScript>();
    }

    //Colliderに触れてる間の処理
    void OnTriggerStay(Collider coll)
    {
        //プレイヤーキャラクターを発見
        if (coll.tag == "Player")
        {
            //エネミーの状態を取得
            EnemyMoveScript.EnemyState state = Enemymove.GetState();
            //エネミーが追いかける状態でなければ追いかける設定に変更
            if (state != EnemyMoveScript.EnemyState.Chase)
            {
                Debug.Log("プレイヤー発見");
                Enemymove.SetState(EnemyMoveScript.EnemyState.Chase, coll.transform);
            }
        }
    }

    //Colliderから離れた時の処理
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            Debug.Log("見失う");
            Enemymove.SetState(EnemyMoveScript.EnemyState.Wait);
        }
    }
}
