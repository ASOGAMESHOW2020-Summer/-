using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamuraiMoveScript : MonoBehaviour
{
    public enum SamuraiState
    {
        Normal,
        Damage,
        Attack,
        Dead
    };

    private SamuraiState state;
    private CharacterController characterController;
    private Animator animator;
    //P1FlashImageを入れるオブジェクト
    private GameObject obj;
    //Flashスクリプト
    private Flash flash;
    //P1DisTanceEnemyスクリプト
    private P1DistanceEnemy distance;
    //DeadImageを入れるオブジェクト
    [SerializeField]
    private GameObject deadImage;
    //SkillDeadImageを入れるオブジェクト
    [SerializeField]
    private GameObject SkillDeadImage;
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
    //エフェクトオブジェクト
    [SerializeField]
    private GameObject damageEffect;
    ///<summary>
    ///使用するInputKey名を入れる
    ///</summary>
    [SerializeField]
    private string horizontalString;
    [SerializeField]
    private string verticalString;
    //鍵フラグ
    private bool KeyFlag = false;
    //攻撃できる回数
    private int AttackNum;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        obj = GameObject.Find("P1FlashImage");
        flash = obj.GetComponent<Flash>();
        distance = GetComponent<P1DistanceEnemy>();
        deadImage.GetComponent<Image>();
        SkillDeadImage.GetComponent<Image>();
        //　体力の初期化
        hp = 3;
        //　体力ゲージに反映
        lifeGauge.SetLifeGauge(hp);
        //鍵フラグの初期化
        KeyFlag = false;
        //攻撃できる回数の初期化
        AttackNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (state == SamuraiState.Dead)
        {
            return;
        }

        if (state == SamuraiState.Normal)
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

                //攻撃処理
                if(Input.GetButtonDown("SamuraiSkill"))
                {
                    Debug.Log("コントローラ１");
                    if (AttackNum >= 3)
                    {
                        SetState(SamuraiState.Attack);
                    }
                    else if(AttackNum == 3)
                    {
                        SkillDeadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    }
                }

                //ジャンプ処理
                if (Input.GetButtonDown("SamuraiJump"))
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
    public void SetState(SamuraiState tempState)
    {
        if (tempState == SamuraiState.Normal)
        {
            state = SamuraiState.Normal;
        }
        else if(tempState == SamuraiState.Attack)
        {
            velocity = Vector3.zero;
            state = SamuraiState.Attack;
            animator.SetTrigger("Attack");
            AttackNum++;
        }
        else if(tempState == SamuraiState.Dead)
        {
            state = SamuraiState.Dead;
        }
    }

    //プレイヤーの状態取得メソッド
    public SamuraiState GetState()
    {
        return state;
    }

    //エネミーから攻撃を受けた時の処理
    public void Damage(Transform enemyTransform,Vector3 attackPlace)
    {
        state = SamuraiState.Damage;
        velocity = Vector3.zero;
        animator.SetTrigger("Damage");
        var damageEffectInstance = Instantiate<GameObject>(damageEffect, attackPlace, Quaternion.identity);
        Destroy(damageEffectInstance, 1f);
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
            state = SamuraiState.Dead;
            velocity = Vector3.zero;
            animator.SetBool("Dead", true);
            distance.enabled = false;
            flash.ColorClear();
            deadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
     
    //鍵フラグを取得するメソッド
    public bool GetKeyFlag()
    {
        return KeyFlag;
    }
    //鍵フラグを設定するメソッド
    public void SetKeyFlag(bool flag)
    {
        KeyFlag = flag;
    }

    //テスト用
    void DeadButton()
    {
        SetState(SamuraiState.Dead);
       // state = SamuraiState.Dead;
        velocity = Vector3.zero;
        animator.SetBool("Dead", true);
        flash.ColorClear();
        Debug.Log(state);
    }
}