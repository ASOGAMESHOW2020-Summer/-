/*エネミーのプレイヤー探知スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter : MonoBehaviour
{
    private NavMeshEnemyMove NavEnemymove;
    
    void Start()
    {
        NavEnemymove = GetComponentInParent<NavMeshEnemyMove>();
    }

    //Colliderに触れてる間の処理
    void OnTriggerStay(Collider coll)
    {
        //プレイヤーキャラクターを発見
        if (coll.tag == "Samurai")
        {
            if (SamuraiMoveScript.samuraiDeadFlag == false)
            {
                //エネミーの状態を取得
                NavMeshEnemyMove.EnemyState state = NavEnemymove.GetState();
                //エネミーが追いかける状態でなければ追いかける設定に変更
                if ((state == NavMeshEnemyMove.EnemyState.Wait || state == NavMeshEnemyMove.EnemyState.Walk))
                {
                    //Debug.Log("プレイヤー発見");
                    NavEnemymove.SetState(NavMeshEnemyMove.EnemyState.Chase, coll.transform);
                }
            }
            else
            {
                return;
            }
        }
        else if(coll.tag == "Monk")
        {
            if (MonkMoveScript.monkDeadFlag == true)
            {
                //エネミーの状態を取得
                NavMeshEnemyMove.EnemyState state = NavEnemymove.GetState();
                //エネミーが追いかける状態でなければ追いかける設定に変更
                if ((state == NavMeshEnemyMove.EnemyState.Wait || state == NavMeshEnemyMove.EnemyState.Walk))
                {
                    //Debug.Log("プレイヤー発見");
                    NavEnemymove.SetState(NavMeshEnemyMove.EnemyState.Chase, coll.transform);
                }
            }
            else
            {
                return;
            }
        }
        else if(coll.tag == "Onmyoji")
        {
            if (OnmyojiMoveScript.onmyojiDeadFlag == true)
            {
                //エネミーの状態を取得
                NavMeshEnemyMove.EnemyState state = NavEnemymove.GetState();
                //エネミーが追いかける状態でなければ追いかける設定に変更
                if ((state == NavMeshEnemyMove.EnemyState.Wait || state == NavMeshEnemyMove.EnemyState.Walk))
                {
                    //Debug.Log("プレイヤー発見");
                    NavEnemymove.SetState(NavMeshEnemyMove.EnemyState.Chase, coll.transform);
                }
            }
            else
            {
                return;
            }
        }
        else if(coll.tag == "Thief")
        {
            if (ThiefMoveScript.thiefDeadFlag == true)
            {
                //エネミーの状態を取得
                NavMeshEnemyMove.EnemyState state = NavEnemymove.GetState();

                if (ThiefMoveScript.CovertFlag == true)
                {
                    return;
                }
                else if (ThiefMoveScript.CovertFlag == false)
                {
                    //エネミーが追いかける状態でなければ追いかける設定に変更
                    if ((state == NavMeshEnemyMove.EnemyState.Wait || state == NavMeshEnemyMove.EnemyState.Walk))
                    {
                        //Debug.Log("プレイヤー発見");
                        NavEnemymove.SetState(NavMeshEnemyMove.EnemyState.Chase, coll.transform);
                    }
                }
                //スキル不使用時
                //エネミーが追いかける状態でなければ追いかける設定に変更
                if ((state == NavMeshEnemyMove.EnemyState.Wait || state == NavMeshEnemyMove.EnemyState.Walk))
                {
                    //Debug.Log("プレイヤー発見");
                    NavEnemymove.SetState(NavMeshEnemyMove.EnemyState.Chase, coll.transform);
                }
            }
            else
            {
                return;
            }
        }
    }

    //Colliderから離れた時の処理
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            //Debug.Log("見失う");
            NavEnemymove.SetState(NavMeshEnemyMove.EnemyState.Wait);
        }
        else if(coll.tag == "Monk")
        {
            //Debug.Log("見失う");
            NavEnemymove.SetState(NavMeshEnemyMove.EnemyState.Wait);
        }
        else if(coll.tag == "Onmyoji")
        {
            //Debug.Log("見失う");
            NavEnemymove.SetState(NavMeshEnemyMove.EnemyState.Wait);
        }
        else if(coll.tag == "Thief")
        {
            //Debug.Log("見失う");
            NavEnemymove.SetState(NavMeshEnemyMove.EnemyState.Wait);
        }
    }
}
