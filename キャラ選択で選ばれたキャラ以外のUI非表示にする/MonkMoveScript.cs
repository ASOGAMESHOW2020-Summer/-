using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonkMoveScript : MonoBehaviour
{
    public enum MonkState
    {
        Normal,
        Dead
    };

    private MonkState state;
    private CharacterController characterController;
    private Animator animator;
    //P2FlashImageを入れるオブジェクト
    private GameObject obj;
    //Flashスクリプト
    private Flash flash;
    //P2DisTanceEnemyスクリプト
    private P2DistanceEnemy distance;
    //DeadImageを入れるオブジェクト
    [SerializeField]
    private GameObject deadImage;
    [SerializeField]
    private GameObject SkillImage;
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
    private int hp;
    //　LifeGaugeスクリプト
    [SerializeField]
    private LifeGauge lifeGauge;
    //ダメージエフェクト
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
    //スキルフラグ
    private bool SkillFlag = false;
    //時間計測
    private float second = 0f;
    //スキル使用回数
    private int SkillNum = 0;
    //エフェクトオブジェクト
    [SerializeField]
    private GameObject skillEffect;
    [SerializeField]
    private ParticleSystem skillParticle;
    //Audio関係
    [SerializeField]
    private AudioClip SkillSe;
    [SerializeField]
    private AudioClip DeadSe;
    [SerializeField]
    private AudioClip DamageSe;
    AudioSource audioSource;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        obj = GameObject.Find("P2FlashImage");
        flash = obj.GetComponent<Flash>();
        distance = GetComponent<P2DistanceEnemy>();
        deadImage.GetComponent<Image>();
        skillEffect = GameObject.Find("LifeRecover");
        skillParticle = skillEffect.GetComponent<ParticleSystem>();
        SkillImage.GetComponent<Image>();
        SkillDeadImage.GetComponent<Image>();
        LifeImage.GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        //　体力の初期化
        hp = 3;
        //　体力ゲージに反映
        lifeGauge.SetLifeGauge(hp);
        //鍵フラグの初期化
        KeyFlag = false;
        second = 0f;
        //スキル回数の初期化
        SkillNum = 0;
        skillParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;
        if (state == MonkState.Dead)
        {
            return;
        }

        if (MonkButton.MonkFlag == true)
        {
            LifeImage.SetActive(true);
            flash.enabled = true;
            SkillImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        }
        else if (MonkButton.MonkFlag == false)
        {
            LifeImage.SetActive(false);
            flash.enabled = false;
            deadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            SkillImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            SkillDeadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
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

                //スキル処理(エネミーの速度を遅くする)
                //if (Input.GetButtonDown("MonkSkill"))
                //{
                //    if (SkillNum <= 3)
                //    {
                //        Debug.Log("コントローラ2");
                //        second = 0f;
                //        SkillFlag = true;
                //        SkillNum++;
                //    }
                //    else if(SkillNum == 3)
                //    {
                //        SkillDeadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                //    }
                //}
                //スキル２（回復）
                if(Input.GetButtonDown("MonkSkill"))
                {
                    if((SkillNum < 1)&&(hp < 3))
                    {
                        audioSource.PlayOneShot(SkillSe);
                        second = 0;
                        Debug.Log("回復");
                       // SkillFlag = true;
                        SkillNum++;
                        hp++;
                        lifeGauge.SetLifeGauge(hp);
                        skillParticle.Play();
                    }
                    else if(SkillNum > 1)
                    {
                       // SkillFlag = false;
                        SkillDeadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    }
                }
                else
                {
                    if (second > 5)
                    {
                        //SkillFlag = false;
                        skillParticle.Stop();
                    }
                }

                //ジャンプ処理
                if (Input.GetButtonDown("MonkJump"))
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
            SetState(MonkState.Dead);
            velocity = Vector3.zero;
            animator.SetBool("Dead", true);
            distance.enabled = false;
            flash.ColorClear();
            Debug.Log(state);
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

    //スキルフラグを取得メソッド
    public bool GetSkillFlag()
    {
        return SkillFlag;
    }
    //スキルフラグを設定するメソッド
    public void SetSkillFlag(bool flag)
    {
        SkillFlag = flag;
    }

    //テスト用
    void DeadButton()
    {
        SetState(MonkState.Dead);
        // state = MonkState.Dead;
        velocity = Vector3.zero;
        animator.SetBool("Dead", true);
        flash.ColorClear();
        Debug.Log(state);
    }
}