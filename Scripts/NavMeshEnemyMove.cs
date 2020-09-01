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
        Freeze,
        Damage,
        DamageWait
    };

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
    ////　歩くスピード
    //[SerializeField]
    //private float walkSpeed = 1.0f;
    //　速度
    private Vector3 velocity;
    //　移動方向
    private Vector3 direction;
    //　到着フラグ
    private bool arrived;
    //待ち時間
    [SerializeField]
    private float waitTime = 5f;
    //ダメージ時の止まる時間
    private float stopTime = 8f;
    //経過時間
    private float elapsedTime;
    //エネミーの状態
    private EnemyState state;
    //追いかけるキャラクター
    private Transform playerTransform;
    private Transform position;
    //攻撃した後の硬直時間
    [SerializeField]
    private float FreezeTime = 0.5f;
    //エフェクトオブジェクト
    [SerializeField]
    private GameObject damageEffect;
    [SerializeField]
    private GameObject MonkObj;
    private MonkMoveScript MonkScript;
    //Audio関係
    [SerializeField]
    private AudioClip DamageSe;
    [SerializeField]
    private AudioClip AttackSe;
    AudioSource audioSource;
    //スキルを食らった時のエフェクト
    [SerializeField]
    private GameObject MonkskillEffect;
    [SerializeField]
    private ParticleSystem MonkskillParticle;
    //スキルを食らった時のエフェクト
    [SerializeField]
    private GameObject OnmyoskillEffect;
    [SerializeField]
    private ParticleSystem OnmyoskillParticle;
    private float second = 0;


    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        setPosition = GetComponent<SetPosition>();
        setPosition.CreateRandomPosition();
        MonkObj = GameObject.Find("僧侶");
        MonkScript = MonkObj.GetComponent<MonkMoveScript>();
        audioSource = GetComponent<AudioSource>();
        velocity = Vector3.zero;
        arrived = false;
        elapsedTime = 0f;
        SetState(EnemyState.Walk);
        second = 0f;
        MonkskillEffect = GameObject.Find("Slow");
        MonkskillParticle = MonkskillEffect.GetComponent<ParticleSystem>();
        OnmyoskillEffect = GameObject.Find("OnmyoSkill");
        OnmyoskillParticle = OnmyoskillEffect.GetComponent<ParticleSystem>();
        //最初はパーティクルの再生を止めておく
        MonkskillParticle.Stop();
        OnmyoskillParticle.Stop();
    }

    void Update()
    {
        //僧侶のスキルが使われた時のエフェクト
        if (MonkButton.MonkFlag == true)
        {
            if (MonkScript.GetSkillFlag() == true)
            {
                MonkskillParticle.Play();
                // walkSpeed = 1.1f;
                navmesh.speed = 2.0f;

                if (MonkScript.GetSkillFlag() == false)
                {
                    MonkskillParticle.Stop();
                    //walkSpeed = 0.8f;
                    navmesh.speed = 3.0f;
                }
            }
        }

        //陰陽師のスキルが使われたとき
        if (OnmyojiButton.OnmyojiFlag == true)
        {
            if (OnmyojiMoveScript.OnmyoFlag == true)
            {
                Debug.Log("動き封じ");
                OnmyoskillParticle.Play();
                SetState(EnemyState.Wait);

                if (OnmyojiMoveScript.OnmyoFlag == false)
                {
                    OnmyoskillParticle.Stop();
                    SetState(EnemyState.Walk);
                }
            }
        }
   
        //見回りまたはキャラクターを追いかける状態
        if (state == EnemyState.Walk || state == EnemyState.Chase)
        {
            //キャラクターを追いかける状態であればキャラクターの目的地を再設定
            if (state == EnemyState.Chase)
            {
                setPosition.SetDestination(playerTransform.position);
                navmesh.SetDestination(setPosition.GetDestination());
            }
            //エージェントの潜在的な速さを設定
            animator.SetFloat("Speed", navmesh.desiredVelocity.magnitude);

            if (state == EnemyState.Walk)
            {
                //目的地に到着したかどうかの判定
                if (navmesh.remainingDistance < 0.1f)
                {
                    SetState(EnemyState.Wait);
                    animator.SetFloat("Speed", 0f);
                }
            }
            else if (state == EnemyState.Chase)
            {
                //攻撃する距離だったら攻撃
                if (navmesh.remainingDistance < 2.5f)
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
        //ダメージを受けたら止まる
        else if (state == EnemyState.DamageWait)
        {
            second += Time.deltaTime;

            //待ち時間を越えたら次の目的地を設定
            if (second > stopTime)
            {
                Debug.Log("許さぬぞ");
                SetState(EnemyState.Walk);
            }
        }
        else if(state == EnemyState.Attack)
        {
            ////プレイヤーの方向を取得
            var playerDirection = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z) - transform.position;
            ////敵の向きをプレイヤーの方向に少しづつ変える
            var dir = Vector3.RotateTowards(transform.forward, playerDirection, rotateSpeed * Time.deltaTime, 0f);
            ////算出した方向の角度を敵の角度に設定
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }

    //エネミーの状態変更メソッド
    public void SetState(EnemyState tempState, Transform targetObj = null)
    {
        state = tempState;
        velocity = Vector3.zero;
        if (tempState == EnemyState.Walk)
        {
            arrived = false;
            elapsedTime = 0f;
            setPosition.CreateRandomPosition();
            navmesh.SetDestination(setPosition.GetDestination());
            navmesh.isStopped = false;
        }
        else if (tempState == EnemyState.Chase)
        {
            Debug.Log("Chase" + state);
            //待機状態から追いかける場合もあるのでOffにする
            arrived = false;
            //追いかける対象をセット
            playerTransform = targetObj;
            navmesh.SetDestination(playerTransform.position);
            navmesh.isStopped = false;
        }
        else if (tempState == EnemyState.Wait)
        {
            Debug.Log("Wait" + state);
            elapsedTime = 0f;
            arrived = true;
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
        }
        else if (tempState == EnemyState.Attack)
        {
            Debug.Log("Attack" + state);
            velocity = Vector3.zero;
            audioSource.PlayOneShot(AttackSe);
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Attack", true);
            navmesh.isStopped = true;
        }
        else if (tempState == EnemyState.Freeze)
        {
            Debug.Log("Freez" + state);
            elapsedTime = 0f;
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Attack", false);
        }
        else if (tempState == EnemyState.Damage)
        {
            Debug.Log("Damage" + state);
            Debug.Log("グワァァァー");
            velocity = Vector3.zero;
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Damage");
            SetState(EnemyState.DamageWait);
        }
        else if (tempState == EnemyState.DamageWait)
        {
            Debug.Log("DamageWait" + state);
            Debug.Log("苦しみ中");
            velocity = Vector3.zero;
            second = 0f;
            animator.SetFloat("Speed", 0f);
            navmesh.isStopped = true;
        }
    }

    //ダメージの処理
    public void Damage(Vector3 attackPlace)
    {
        audioSource.PlayOneShot(DamageSe);
        SetState(EnemyState.Damage);
        var damageEffectInstance = Instantiate<GameObject>(damageEffect);
        damageEffectInstance.transform.position = attackPlace;
        Destroy(damageEffectInstance, 1f);
    }


    //エネミーの状態取得メソッド
    public EnemyState GetState()
    {
        return state;
    }
}
