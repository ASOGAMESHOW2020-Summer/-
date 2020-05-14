using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    //エネミーのキャラクターコントローラ
    private CharacterController enemyController;
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
    private float elapstedTime;

    // Use this for initialization
    void Start()
    {
        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        setPosition = GetComponent<SetPosition>();
        //ランダムな位置の作成と設定
        setPosition.CreateRandomPosition();
        //目的地の取得
        destination = setPosition.getDestination();
        //経過時間の初期値設定
        elapstedTime = 0f;
        //velocityにゼロを設定
        velocity = Vector3.zero;
        arrived = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!arrived)
        {
            if (enemyController.isGrounded)
            {
                velocity = Vector3.zero;
                animator.SetFloat("Speed", 2.0f);
                direction = (destination - transform.position).normalized;
                transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
                velocity = direction * walkSpeed;
                Debug.Log(destination);
            }
            velocity.y += Physics.gravity.y * Time.deltaTime;
            enemyController.Move(velocity * Time.deltaTime);

            //　目的地に到着したかどうかの判定
            //2地点の距離を求めて判断
            if (Vector3.Distance(transform.position, destination) < 0.5f)//距離が0.5未満になったら
            {
                arrived = true;
                animator.SetFloat("Speed", 0.0f);
            }
        }
        else
        {
            elapstedTime += Time.deltaTime;
            //待ち時間を超えたら次の目的地を設定
            if(elapstedTime > waitTime)
            {
                setPosition.CreateRandomPosition();
                destination = setPosition.getDestination();
                arrived = false;
                elapstedTime = 0f;
            }
        }
    }
}