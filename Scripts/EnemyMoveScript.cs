using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    //エネミーのキャラクターコントローラ
    private CharacterController enemyController;
    //エネミーのアニメータ
    private Animator animator;
    //　目的地
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
    //　スタート位置
    private Vector3 startPosition;


    // Use this for initialization
    void Start()
    {
        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //Vector2のランダム位置を生成（半径10メートル）
        var randDestination = Random.insideUnitCircle * 10;
        //スタートポイントにランダムな位置を足して目的地にする
        destination = startPosition + new Vector3(randDestination.x, 0, randDestination.y);
        velocity = Vector3.zero;
        arrived = false;
        startPosition = transform.position;
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
    }
}