/*盗賊の行動スクリプト*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThiefMoveScript : MonoBehaviour
{
    public enum ThiefState
    {
        Normal,
        Dead
    };

    private ThiefState state;
    private CharacterController characterController;
    private Animator animator;
    //P4FlashImageを入れるオブジェクト
    private GameObject obj;
    //Flashスクリプト
    private Flash flash;
    //P4DisTanceEnemyスクリプト
    private P4DistanceEnemy distance;
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
    //スキル使用回数（MAX)
    private const int SkillNumMax = 3;
    //スキルを使用した回数
    private int SkillNum = 0;
    //スキル時間
    private float second;
    //エフェクトオブジェクト
    [SerializeField]
    private GameObject skillEffect;
    [SerializeField]
    private ParticleSystem skillParticle;
    //Audio関係
    [SerializeField]
    private AudioClip SpeedSkillSe;
    [SerializeField]
    private AudioClip CovertSkillSe;
    [SerializeField]
    private AudioClip DeadSe;
    [SerializeField]
    private AudioClip DamageSe;
    AudioSource audioSource;
    //アイテムスキル関係
    [SerializeField]
    private GameObject otakaraobj;
    private Otakara otakara;
    public static bool CovertFlag = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        obj = GameObject.Find("P4FlashImage");
        flash = obj.GetComponent<Flash>();
        distance = GetComponent<P4DistanceEnemy>();
        deadImage.GetComponent<Image>();
        skillEffect = GameObject.Find("Wind");
        skillParticle = skillEffect.GetComponent<ParticleSystem>();
        SkillDeadImage.GetComponent<Image>();
        LifeImage.GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        otakaraobj = GameObject.Find("OtakaraSkill");
        otakara = otakaraobj.GetComponent<Otakara>();
        CovertFlag = false;
        //　体力の初期化
        hp = 3;
        //　体力ゲージに反映
        lifeGauge.SetLifeGauge(hp);
        //鍵フラグの初期化
        KeyFlag = false;
        //時間の初期化
        second = 0f;
        SkillNum = 0;
    }


    void Update()
    {
        second += Time.deltaTime;

        if (state == ThiefState.Dead)
        {
            return;
        }

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

        if (ThiefButton.ThiefFlag == true)
        {
            this.gameObject.SetActive(true);
            LifeImage.SetActive(true);
            flash.enabled = true;

        }
        else if (ThiefButton.ThiefFlag == false)
        {
            this.gameObject.SetActive(false);
            LifeImage.SetActive(false);
            flash.enabled = false;
            deadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            SkillDeadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }

        if (state == ThiefState.Normal)
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

                var positon = transform.position;
                //スキル処理（一定時間速度を上げる）
                if (otakara.GetOtakaraFlag() == true)
                {
                    //ゲームパッドのYボタンを押したとき
                    if(Input.GetButtonDown("ThiefItem"))
                    {
                        Debug.Log("コントローラ4");
                        if (SkillNum < SkillNumMax)
                        {
                            if (SkillNum < 3)
                            {
                                audioSource.PlayOneShot(SpeedSkillSe);
                                second = 0f;
                                walkSpeed = 4f;
                                runSpeed = 8f;
                                Debug.Log("韋駄天なり");
                                Debug.Log(walkSpeed);
                                Debug.Log(runSpeed);
                                SkillNum++;
                                Debug.Log(SkillNum);
                                skillParticle.Play();
                            }
                            else if (SkillNum >= 3)
                            {
                                SkillDeadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                            }
                        }
                    }
                    else
                    {
                        if (second > 15)
                        {
                            skillParticle.Stop();
                            walkSpeed = 4f;
                            runSpeed = 6f;
                        }
                    }
                }

                //スキル敵から認知されない（ゲームパッドのRBボタン押したとき）
                if (Input.GetButtonDown("ThiefSkill"))
                {
                    second = 0;
                    CovertFlag = true;
                    audioSource.PlayOneShot(CovertSkillSe);
                    if(second > 15.0f)
                    {
                        CovertFlag = false;
                    }
                }

                //ジャンプ処理（ゲームパッドのAボタンを押したとき）
                if (Input.GetButtonDown("ThiefJump"))
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
    public void SetState(ThiefState tempState)
    {
        if (tempState == ThiefState.Normal)
        {
            state = ThiefState.Normal;
        }
        else if(tempState == ThiefState.Dead)
        {
            state = ThiefState.Dead;
        }
    }

    //プレイヤーの状態取得メソッド
    public ThiefState GetState()
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
            SetState(ThiefState.Dead);
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

    //テスト用
    void DeadButton()
    {
        SetState(ThiefState.Dead);
        //state = ThiefState.Dead;
        velocity = Vector3.zero;
        animator.SetBool("Dead", true);
        flash.ColorClear();
        Debug.Log(state);
    }
}
