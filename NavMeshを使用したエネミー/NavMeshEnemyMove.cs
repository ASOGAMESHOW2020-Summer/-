using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemyMove : MonoBehaviour
{
    //エネミーステート
    public enum EnemyState
    {
        Walk,
        Wait,
        Chase,
        Attack,
        Freeze
    };

    //エネミーのキャラクターコントローラ
    // private CharacterController enemyController;
    //エージェント
    private NavMeshAgent navmesh;
    //回転スピード
    [SerializeField]
    private float rotateSpeed = 45f;
    //エネミーのアニメータ
    private Animator animator;
    //SetPositionスクリプト
    private SetPosition setPosition;
    //目的地
    private Vector3 destination;
    //　歩くスピード
    [SerializeField]
    private float walkSpeed = 1.0f;
    //　速度
    private Vector3 velocity;
    //　移動方向
    private Vector3 direction;
    //　到着フラグ
    private bool arrived;
    //待ち時間
    [SerializeField]
    private float waitTime = 5f;
    //経過時間
    private float elapsedTime;
    //エネミーの状態
    private EnemyState state;
    //追いかけるキャラクター
    private Transform playerTransform;
    //攻撃した後の硬直時間
    [SerializeField]
    private float FreezeTime = 0.5f;


    void Start()
    {
        //enemyController = GetComponent<CharacterController>();
        navmesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        setPosition = GetComponent<SetPosition>();
        setPosition.CreateRandomPosition();
        velocity = Vector3.zero;
        arrived = false;
        elapsedTime = 0f;
        SetState(EnemyState.Walk);
    }

    void Update()
    {
        //見回りまたはキャラクターを追いかける状態
        if (state == EnemyState.Walk || state == EnemyState.Chase)
        {
            //キャラクターを追いかける状態であればキャラクターの目的地を再設定
            if (state == EnemyState.Chase)
            {
                setPosition.SetDestination(playerTransform.position);
                navmesh.SetDestination(setPosition.GetDestination());
            }
            //if (enemyController.isGrounded)
            //{
            //    velocity = Vector3.zero;
            //    animator.SetFloat("Speed", 2.0f);
            //    direction = (setPosition.GetDestination() - transform.position).normalized;
            //    transform.LookAt(new Vector3(setPosition.GetDestination().x, transform.position.y, setPosition.GetDestination().z));
            //    velocity = direction * walkSpeed;
            //}
            //エージェントの潜在的な速さを設定
            animator.SetFloat("Speed", navmesh.desiredVelocity.magnitude);

            if (state == EnemyState.Walk)
            {
                //目的地に到着したかどうかの判定
                //if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 0.5f)
                if(navmesh.remainingDistance < 0.1f)
                {
                    SetState(EnemyState.Wait);
                    animator.SetFloat("Speed", 0.0f);
                }
            }
            else if (state == EnemyState.Chase)
            {
                //攻撃する距離だったら攻撃
                //if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 1f)
                if(navmesh.remainingDistance < 1.2f)
                {
                    SetState(EnemyState.Attack);
                }
            }
        } //到着していたら一定時間待つ
        else if (state == EnemyState.Wait)
        {
            elapsedTime += Time.deltaTime;

            //待ち時間を越えたら次の目的地を設定
            if (elapsedTime > waitTime)
            {
                SetState(EnemyState.Walk);
            }
        }
        //攻撃したら一定時間フリーズさせる
        else if (state == EnemyState.Freeze)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > FreezeTime)
            {
                SetState(EnemyState.Walk);
            }
        }
        else if(state == EnemyState.Attack)
        {
            //プレイヤーの方向を取得
            var playerDirection = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z) - transform.position;
            //敵の向きをプレイヤーの方向に少しづつ変える
            var dir = Vector3.RotateTowards(transform.forward, playerDirection, rotateSpeed * Time.deltaTime, 0f);
            //算出した方向の角度を敵の角度に設定
            transform.rotation = Quaternion.LookRotation(dir);
        }
       // velocity.y += Physics.gravity.y * Time.deltaTime;
        //enemyController.Move(velocity * Time.deltaTime);
    }

    //エネミーの状態変更メソッド
    public void SetState(EnemyState tempState, Transform targetObj = null)
    {
        if (tempState == EnemyState.Walk)
        {
            arrived = false;
            elapsedTime = 0f;
            state = tempState;
            setPosition.CreateRandomPosition();
            navmesh.SetDestination(setPosition.GetDestination());
            navmesh.isStopped = false;
        }
        else if (tempState == EnemyState.Chase)
        {
            state = tempState;
            //待機状態から追いかける場合もあるのでOffにする
            arrived = false;
            //追いかける対象をセット
            //　追いかける対象をセット
            playerTransform = targetObj;
            navmesh.SetDestination(playerTransform.position);
            navmesh.isStopped = false;
        }
        else if (tempState == EnemyState.Wait)
        {
            elapsedTime = 0f;
            state = tempState;
            arrived = true;
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
        }
        else if (tempState == EnemyState.Attack)
        {
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Attack", true);
            navmesh.isStopped = true;
        }
        else if (tempState == EnemyState.Freeze)
        {
            elapsedTime = 0f;
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Attack", false);
        }
    }
    //エネミーの状態取得メソッド
    public EnemyState GetState()
    {
        return state;
    }
}
