using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject targetObj;
    Vector3 targetPos;
    Vector3 roteuler;

    //回転の制限
    [SerializeField] float ANGLE_LIMIT_UP = 45f;
    [SerializeField] float ANGLE_LIMIT_DOWN = -45f;

    void Start()
    {
        targetPos = targetObj.transform.position;
        roteuler = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);
    }

    void Update()
    {
        rotateCameraAngle();
    }

    //カメラの回転制御
    private void rotateCameraAngle()
    {
        // targetの移動量分、自分（カメラ）も移動する
        //transform.position += targetObj.transform.position - targetPos;
        //targetPos = targetObj.transform.position;

        //パッドの移動量
        float padInputX = Input.GetAxis("R_Stick_H");
        float padInputY = Input.GetAxis("R_Stick_V");

        // targetの位置のY軸を中心に、回転（公転）する
        transform.RotateAround(targetPos, Vector3.up, padInputX * Time.deltaTime * 300f);

        //カメラの垂直移動(角度制限あり)
        roteuler = new Vector3(Mathf.Clamp(roteuler.x - padInputY * Time.deltaTime * 200f,
            ANGLE_LIMIT_DOWN, ANGLE_LIMIT_UP),
            transform.localEulerAngles.y, 0f);
    }
}
