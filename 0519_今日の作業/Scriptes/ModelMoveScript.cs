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
    //　ジャンプ力
    [SerializeField]
    private float jumpPower = 5f;


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
            //ジャンプ処理
            if (Input.GetKeyDown("joystick button 3"))//ゲームパッドのYボタンを押したら
            {
                animator.SetBool("JumpFlag",true);
                velocity.y += jumpPower;
            }

            velocity = Vector3.zero;

            var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (input.magnitude > 0.1f)
            {
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
        }
        else
        {
            animator.SetBool("JumpFlag", false);
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
