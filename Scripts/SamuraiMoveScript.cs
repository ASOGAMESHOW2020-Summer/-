/*侍の行動スクリプト*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamuraiMoveScript : MonoBehaviour
{
    public enum SamuraiState
    {
        Normal,
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
    [SerializeField]
    private GameObject LifeImage;
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
    public static int hp;
    //　LifeGaugeスクリプト
    [SerializeField]
    private LifeGauge lifeGauge;
    //エフェクトオブジェクト
    [SerializeField]
    private GameObject damageEffect;
    private string horizontalString;
    private string verticalString;
    //鍵フラグ
    private bool KeyFlag = false;
    //攻撃できる回数
    private int AttackNum;
    //スキルフラグ
    private bool SkillFlag = false;
    //Audio
    [SerializeField]
    private AudioClip SkillSe;
    [SerializeField]
    private AudioClip DeadSe;
    [SerializeField]
    private AudioClip DamageSe;
    AudioSource audioSource;
    //アイテムを入れるオブジェクト
    [SerializeField]
    private GameObject katanaobj;
    private Katana katana;
    //防御スキルフラグ
    public static bool YoroiFlag = false;
    //防御スキル使用回数
    private int num;
    //死亡フラグ
    public static bool samuraiDeadFlag = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        obj = GameObject.Find("P1FlashImage");
        flash = obj.GetComponent<Flash>();
        distance = GetComponent<P1DistanceEnemy>();
        deadImage.GetComponent<Image>();
        SkillDeadImage.GetComponent<Image>();
        LifeImage.GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        katanaobj = GameObject.Find("KatanaSkill");
        katana = katanaobj.GetComponent<Katana>();
        //　体力の初期化
        hp = 3;
        //　体力ゲージに反映
        lifeGauge.SetLifeGauge(hp);
        //鍵フラグの初期化
        KeyFlag = false;
        //攻撃できる回数の初期化
        AttackNum = 0;
        //攻撃スキルフラグ
        SkillFlag = false;
        //防御スキルフラグ
        YoroiFlag = false;
        //防御スキルの使用回数の初期化
        num = 0;
        //死亡フラグ初期化
        samuraiDeadFlag = false;
        //ゲームパッドでの操作分け
        if (GamePadConnectNum.pad1 == true)
        {
            horizontalString = "Horizontal";
            verticalString = "Vertical";
        }
        else if (GamePadConnectNum.pad2 == true)
        {
            horizontalString = "Horizontal2";
            verticalString = "Vertical2";
        }
        else if (GamePadConnectNum.pad3 == true)
        {
            horizontalString = "Horizontal3";
            verticalString = "Vertical3";
        }
        else if (GamePadConnectNum.pad4 == true)
        {
            horizontalString = "Horizontal4";
            verticalString = "Vertical4";
        }
    }

    void Update()
    {
        //死亡状態だったら何の処理もせずに帰す
        if (state == SamuraiState.Dead)
        {
            return;
        }
        
        //侍が選ばれたら表示する
        if (SamuraiButton.SamuraiFlag == true)
        {
            this.gameObject.SetActive(true);
            LifeImage.SetActive(true);
            flash.enabled = true;
   
        }
        //侍が選ばれてないなら非表示
        else if(SamuraiButton.SamuraiFlag == false)
        {
            this.gameObject.SetActive(false);
            LifeImage.SetActive(false);
            flash.enabled = false;
            deadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            SkillDeadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
        
        //侍の状態がノーマル状態の時
        if (state == SamuraiState.Normal)
        {
            //デバッグ用（死亡状態になる）
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
                        //走る処理
                        velocity += transform.forward * runSpeed;
                    }
                    else
                    {
                        //歩く処理
                        velocity += transform.forward * walkSpeed;
                    }
                }
                else
                {
                    animator.SetFloat("Speed", 0f);
                }

                //攻撃処理
                if (katana.GetKatanaFlag() == true)
                {
                    //ゲームパッドのYボタンを押したとき
                    if(Input.GetButtonDown("SamuraiItem"))
                    {
                        if (AttackNum < num)
                        {
                            audioSource.PlayOneShot(SkillSe);
                            SetState(SamuraiState.Attack);
                        }
                        else if (AttackNum >= num)
                        {
                            SkillDeadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                            katana.SetKatanaFlag(false);
                        }
                    }
                }

                //防御スキル（ゲームパッドのRBボタンを押したとき）
                if (Input.GetButtonDown("SamuraiSkill"))
                {
                    var count = 1;//スキルの使用回数上限
                    if (num < count)
                    {
                        YoroiFlag = true;
                        num++;
                    }
                }

                //ジャンプ処理(ゲームパッドキーAボタン）
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
            SkillFlag = true;
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
        velocity = Vector3.zero;
        animator.SetTrigger("Damage");
        var damageEffectInstance = Instantiate<GameObject>(damageEffect, attackPlace, Quaternion.identity);
        Destroy(damageEffectInstance, 1f);
    }

    //ライフを減らす処理
    public void LifeDamage(int damage)
    {
        audioSource.PlayOneShot(DamageSe);
        hp -= damage;
        //　0より下の数値にならないようにする
        hp = Mathf.Max(0, hp);

        if (hp >= 0)
        {
            lifeGauge.SetLifeGauge(hp);
        }

        if (hp <= 0)
        {
            audioSource.PlayOneShot(DeadSe);
            SetState(SamuraiState.Dead);
            velocity = Vector3.zero;
            animator.SetBool("Dead", true);
            distance.enabled = false;
            flash.ColorClear();
            deadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            samuraiDeadFlag = true;
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

    //スキルフラグを取得するメソッド
    public bool GetSkillFlag()
    {
        return SkillFlag;
    }
    //スキルフラグを設定するメソッド
    public void SetSkillFlag(bool flag)
    {
        SkillFlag = flag;
    }

    //テスト用（死亡させる処理）
    void DeadButton()
    {
        SetState(SamuraiState.Dead);
        velocity = Vector3.zero;
        animator.SetBool("Dead", true);
        flash.ColorClear();
    }
}