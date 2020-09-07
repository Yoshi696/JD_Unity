using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Camera cam;

    public float Sensitivity = 500f;
    float ContSensitivity = 200f;

    private bool ControllerFlg = true;

    public Transform player;

    float xRot = 0f;

    private GameObject play;   //プレイヤー情報格納用
    private Vector3 offset;    //相対距離取得用


    private void Start()
    {
        cam = this.gameObject.GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;

        ////unitychanの情報を取得
        play = GameObject.Find("Player2");

        //// MainCamera(自分自身)とplayerとの相対距離を求める
        //offset = transform.position - player.transform.position;

    }

    private void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(play.transform.rotation.x, play.transform.rotation.y, play.transform.rotation.z);

        ////新しいトランスフォームの値を代入する
        //transform.position = player.transform.position + offset;

        var controllerNames = Input.GetJoystickNames();
        if (controllerNames[0] == "") ControllerFlg = false;
        else ControllerFlg = true;

        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        float ContX = Input.GetAxis("R_Stick_H") * ContSensitivity * Time.deltaTime;
        float ContY = Input.GetAxis("R_Stick_V") * ContSensitivity * Time.deltaTime;

        if (!ControllerFlg) xRot -= mouseY;
        else xRot -= ContY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
        player.Rotate(Vector3.up * ContX);

    }
}
