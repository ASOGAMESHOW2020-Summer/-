using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject playerObject;
    public float rotateSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.gameObject;
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rotateCamera();
    }

    private void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        //transform.RotateAround()をしようしてメインカメラを回転させる
        mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
        mainCamera.transform.RotateAround(playerObject.transform.position, transform.right, angle.y);
    }
}