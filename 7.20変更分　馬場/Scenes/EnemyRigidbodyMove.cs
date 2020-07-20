using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRigidbodyMove : MonoBehaviour
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

	private Animator animator;
	//　レイを飛ばす体の位置
	[SerializeField]
	private Transform charaRay;
	//　レイの距離
	[SerializeField]
	private float charaRayRange = 0.2f;
	//　レイが地面に到達しているかどうか
	private bool isGround;
	//　rigidbody
	private Rigidbody rigid;
	private bool isGroundCollider = false;
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
	//ダメージ時の止まる時間
	private float stopTime = 8f;
	//経過時間
	private float elapsedTime;
	//エネミーの状態
	private EnemyState state;
	//追いかけるキャラクター
	private Transform playerTransform;
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
		animator = GetComponent<Animator>();
		velocity = Vector3.zero;
		isGround = false;
		rigid = GetComponent<Rigidbody>();
	}

	void Update()
	{

		//　キャラクターが接地していない時はレイを飛ばして確認
		if (!isGroundCollider)
		{
			if (Physics.Linecast(charaRay.position, (charaRay.position - transform.up * charaRayRange)))
			{
				isGround = true;
				rigid.useGravity = true;
			}
			else
			{
				isGround = false;
				rigid.useGravity = false;
			}
			Debug.DrawLine(charaRay.position, (charaRay.position - transform.up * charaRayRange), Color.red);
		}
		//見回りまたはキャラクターを追いかける状態
		if (state == EnemyState.Walk || state == EnemyState.Chase)
		{
			//キャラクターを追いかける状態であればキャラクターの目的地を再設定
			if (state == EnemyState.Chase)
			{
				setPosition.SetDestination(playerTransform.position);
			}

			//　キャラクターコライダが接地、またはレイが地面に到達している場合
			if (isGroundCollider || isGround)
			{
				//　地面に接地してる時は初期化
				if (isGroundCollider)
				{
					velocity = Vector3.zero;
					animator.SetFloat("Speed", 2.0f);
					direction = (setPosition.GetDestination() - transform.position).normalized;
					transform.LookAt(new Vector3(setPosition.GetDestination().x, transform.position.y, setPosition.GetDestination().z));
					rigid.useGravity = true;
				}
				//　レイを飛ばして接地確認の場合は重力だけは働かせておく、前後左右は初期化
				else
				{
					velocity = new Vector3(0f, velocity.y, 0f);
				}
			}
			 if (state == EnemyState.Walk)
            {
                //目的地に到着したかどうかの判定
                if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 0.5f)
                {
                    SetState(EnemyState.Wait);
                    animator.SetFloat("Speed", 0.0f);
                }
            }
            else if (state == EnemyState.Chase)
            {
                //攻撃する距離だったら攻撃
                if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 1f)
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
		if (!isGroundCollider && !isGround)
		{
			velocity.y += Physics.gravity.y * Time.deltaTime;
		}
	}
	void FixedUpdate()
	{
		//　キャラクターを移動させる処理
		rigid.MovePosition(transform.position + velocity * Time.deltaTime);
	}

	void OnCollisionEnter()
	{

		Debug.DrawLine(charaRay.position, charaRay.position + Vector3.down, Color.blue);

		//　他のコライダと接触している時は下向きにレイを飛ばしFieldかBlockレイヤーの時だけ接地とする
		if (Physics.Linecast(charaRay.position, charaRay.position + Vector3.down, LayerMask.GetMask("Field", "Block")))
		{
			isGroundCollider = true;
		}
		else
		{
			isGroundCollider = false;
		}
	}

	//　接触していなければ空中に浮いている状態
	void OnCollisionExit()
	{
		isGroundCollider = false;
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
		}
		else if (tempState == EnemyState.Chase)
		{
			state = tempState;
			//待機状態から追いかける場合もあるのでOffにする
			arrived = false;
			//追いかける対象をセット
			playerTransform = targetObj;
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
			audioSource.PlayOneShot(AttackSe);
			velocity = Vector3.zero;
			animator.SetFloat("Speed", 0f);
			animator.SetBool("Attack", true);
		}
		else if (tempState == EnemyState.Freeze)
		{
			elapsedTime = 0f;
			velocity = Vector3.zero;
			animator.SetFloat("Speed", 0f);
			animator.SetBool("Attack", false);
		}
		else if (tempState == EnemyState.Damage)
		{
			Debug.Log("グワァァァー");
			animator.ResetTrigger("Attack");
			animator.SetTrigger("Damage");
			SetState(EnemyState.DamageWait);
		}
		else if (tempState == EnemyState.DamageWait)
		{
			Debug.Log("苦しみ中");
			second = 0f;
			state = tempState;
			velocity = Vector3.zero;
			animator.SetFloat("Speed", 0f);
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

