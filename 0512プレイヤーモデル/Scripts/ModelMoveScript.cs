using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMoveScript : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)//キャラクターが接地しているかどうか
        {
            
            velocity = Vector3.zero;//速度をゼロにする

            //横軸と縦軸の入力をインプットに代入
            var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

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
                animator.SetBool("JumpFlag",false);
            }

        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

    }

}
