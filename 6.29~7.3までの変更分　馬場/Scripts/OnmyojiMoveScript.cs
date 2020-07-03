/*陰陽師行動スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnmyojiMoveScript : MonoBehaviour
{
    public enum OnmyojiState
    {
        Normal,
        Dead
    };

    private OnmyojiState state;
    private CharacterController characterController;
    private Animator animator;
    //P3FlashImageを入れるオブジェクト
    private GameObject obj;
    //Flashスクリプト
    private Flash flash;
    //P3DisTanceEnemyスクリプト
    private P3DistanceEnemy distance;
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
    //スキル使用フラグ
    private bool SkillFlag = false;
    //スキル使用フラグ2
    public static bool OnmyoFlag = false;
    //エフェクトオブジェクト
    [SerializeField]
    private GameObject skillEffect;
    [SerializeField]
    private ParticleSystem skillParticle;
    private int SkillNum = 0;
    //Audio関係
    [SerializeField]
    private AudioClip SkillSe;
    [SerializeField]
    private AudioClip DeadSe;
    [SerializeField]
    private AudioClip DamageSe;
    AudioSource audioSource;
    //アイテムスキル関係
    [SerializeField]
    private GameObject gofuobj;
    private Gofu gofu;
    private float second;
    private int num;
    //InputString
    string Horizontal, Horizontal2, Horizontal3, Horizontal4;
    string Vertical, Vertical2, Vertical3, Vertical4;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        obj = GameObject.Find("P3FlashImage");
        flash = obj.GetComponent<Flash>();
        distance = GetComponent<P3DistanceEnemy>();
        deadImage.GetComponent<Image>();
        skillEffect = GameObject.Find("Star");
        skillParticle = skillEffect.GetComponent<ParticleSystem>();
        SkillImage.GetComponent<Image>();
        SkillDeadImage.GetComponent<Image>();
        LifeImage.GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        gofuobj = GameObject.Find("GofuSkill");
        gofu = gofuobj.GetComponent<Gofu>();
        //　体力の初期化
        hp = 3;
        //　体力ゲージに反映
        lifeGauge.SetLifeGauge(hp);
        //鍵フラグの初期化
        KeyFlag = false;
        SkillNum = 0;
        OnmyoFlag = false;
        //時間の初期化
        second = 0;
        num = 0;
        skillParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == OnmyojiState.Dead)
        {
            return;
        }

        second += Time.deltaTime;

        // //ゲームパッドでの操作分け
        if (OnmyojiButton.GamePad1 == true)
        {
            horizontalString = Horizontal;
            verticalString = Vertical;
        }
        else if (OnmyojiButton.GamePad2 == true)
        {
            horizontalString = Horizontal2;
            verticalString = Vertical2;
        }
        else if (OnmyojiButton.GamePad3 == true)
        {
            horizontalString = Horizontal3;
            verticalString = Vertical3;
        }
        else if (OnmyojiButton.GamePad4 == true)
        {
            horizontalString = Horizontal4;
            verticalString = Vertical4;
        }

        if (OnmyojiButton.OnmyojiFlag == true)
        {
            this.gameObject.SetActive(true);
            LifeImage.SetActive(true);
            flash.enabled = true;
            SkillImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (OnmyojiButton.OnmyojiFlag == false)
        {
            this.gameObject.SetActive(false);
            LifeImage.SetActive(false);
            flash.enabled = false;
            deadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            SkillImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            SkillDeadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }

        if (state == OnmyojiState.Normal)
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
                        //Debug.Log(velocity);
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

                //スキル処理
                if (gofu.GetGofuFlag() == true)
                {
                    //ゲームパッドのYボタン押したとき
                    if(Input.GetButtonDown("OnmyojiItem"))
                    {
                        if (SkillNum < 3)
                        {
                            audioSource.PlayOneShot(SkillSe);
                            Debug.Log("コントローラ3");
                            SkillFlag = true;
                            Debug.Log("スキルON");
                            skillParticle.Play();
                        }
                        else if (SkillNum >= 3)
                        {
                            SkillDeadImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        }
                    }

                    if (SkillFlag == false)
                    {
                        skillParticle.Stop();
                    }
                }

                //エネミーの動きを止める（ゲームパッドのRBを押したとき）
                if (Input.GetButtonDown("OnmyojiSkill"))
                {
                    second = 0;
                    if (num < 3)
                    {
                        if (second > 15.0f)
                        {
                            OnmyoFlag = true;
                            num++;
                        }
                        else if (second < 15.0f)
                        {
                            OnmyoFlag = false;
                        }
                    }
                    else
                    {
                        return;
                    }
                    
                }

                //ジャンプ処理（ゲームパッドのAボタンを押したとき）
                if (Input.GetButtonDown("OnmyojiJump"))
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
    public void SetState(OnmyojiState tempState)
    {
        if (tempState == OnmyojiState.Normal)
        {
            state = OnmyojiState.Normal;
        }
        else if (tempState == OnmyojiState.Dead)
        {
            state = OnmyojiState.Dead;
        }
    }

    //プレイヤーの状態取得メソッド
    public OnmyojiState GetState()
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

    //スキル使用時の処理
    public void SkillEffect(Vector3 attackPlace)
    {
        var skillEffectInstance = Instantiate<GameObject>(skillEffect, attackPlace, Quaternion.identity);
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
            SetState(OnmyojiState.Dead);
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
        SetState(OnmyojiState.Dead);
        //state = OnmyojiState.Dead;
        velocity = Vector3.zero;
        animator.SetBool("Dead", true);
        flash.ColorClear();
        Debug.Log(state);
        
    }
}