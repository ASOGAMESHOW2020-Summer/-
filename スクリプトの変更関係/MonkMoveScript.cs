using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkMoveScript : MonoBehaviour
{
    public enum MonkState
    {
        Normal,
        Damage,
        Dead
    };

    private MonkState state;
    private CharacterController characterController;
    private Animator animator;
    //　キャラクターの速度
    private Vector3 velocity;
    //　キャラクターの歩くスピード
    [SerializeField]
    private float walkSpeed = 2f;
    //　キャラクターの走るスピード
    [SerializeField]
    private float runSpeed = 4f;
    //　通常のジャンプ力
    [SerializeField]
    private float jumpPower = 5f;
    //　走っている時のジャンプ力
    [SerializeField]
    private float dashJumpPower = 5.6f;
    //　HP
    [SerializeField]
    private int hp;
    //　LifeGaugeスクリプト
    [SerializeField]
    private LifeGauge lifeGauge;
    ///<summary>
    ///使用するInputKey名を入れる
    ///</summary>
    [SerializeField]
    private string horizontalString;
    [SerializeField]
    private string verticalString;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //　体力の初期化
        hp = 3;
        //　体力ゲージに反映
        lifeGauge.SetLifeGauge(hp);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (state == MonkState.Dead)
        {
            return;
        }

        if (state == MonkState.Normal)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                DeadButton();
            }
            if (characterController.isGrounded)//キャラクターが接地しているかどうか
            {

                velocity = Vector3.zero;//速度をゼロにする

                //横軸と縦軸の入力をインプットに代入
                var input = new Vector3(Input.GetAxis(horizontalString), 0f, Input.GetAxis(verticalString));

                if (input.magnitude > 0.1f)//入力の長さを得て0.1より大きいか判断
                {
                    //引数で指定したベクトルの方向を向かせるメソッド
                    transform.LookAt(transform.position + input.normalized);
                    animator.SetFloat("Speed", input.magnitude);
                    if (input.magnitude > 0.5f)
                    {
                        velocity += transform.forward * runSpeed;
                        Debug.Log(velocity);
                    }
                    else
                    {
                        velocity += transform.forward * walkSpeed;
                    }
                }
                else
                {
                    animator.SetFloat("Speed", 0f);
                }

                //ジャンプ処理
                if (Input.GetKeyDown("joystick button 3"))
                {
                    animator.SetBool("JumpFlag", true);
                    //　走って移動している時はジャンプ力を上げる
                    if (input.magnitude > 0.5f)
                    {
                        velocity.y += dashJumpPower;
                    }
                    else
                    {
                        velocity.y += jumpPower;
                    }
                }
                else
                {
                    animator.SetBool("JumpFlag", false);
                }
            }
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);


    }

    //プレイヤーの状態変更メソッド
    public void SetState(MonkState tempState)
    {
        if (tempState == MonkState.Normal)
        {
            state = MonkState.Normal;
        }
        else if (tempState == MonkState.Dead)
        {
            state = MonkState.Dead;
        }
    }

    //プレイヤーの状態取得メソッド
    public MonkState GetState()
    {
        return state;
    }

    //エネミーから攻撃を受けた時の処理
    public void Damage(Transform enemyTransform)
    {
        state = MonkState.Damage;
        velocity = Vector3.zero;
        animator.SetTrigger("Damage");
    }

    //ライフを減らす処理
    public void LifeDamage(int damage)
    {
        hp -= damage;
        //　0より下の数値にならないようにする
        hp = Mathf.Max(0, hp);

        if (hp >= 0)
        {
            lifeGauge.SetLifeGauge(hp);
        }

        if (hp <= 0)
        {
            state = MonkState.Dead;
            velocity = Vector3.zero;
            animator.SetBool("Dead", true);
        }

    }

    //テスト用
    void DeadButton()
    {
        SetState(MonkState.Dead);
        // state = MonkState.Dead;
        velocity = Vector3.zero;
        animator.SetBool("Dead", true);
        Debug.Log(state);
    }
}