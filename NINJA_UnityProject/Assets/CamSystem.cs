﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class CamSystem : MonoBehaviour
{
    //カメラ型の変数
    public GameObject cam;

    //視点の回転速度
    public float Sensitivity = 500f;
    float ContSensitivity = 200f;

    //コントローラーが刺さってるかどうかのフラグ
    private bool ControllerFlg = true;

    //プレイヤーの回転アングル
    float xRot = 0f;

    private GameObject play;   //プレイヤー情報格納用
    private Vector3 offset;    //相対距離取得用

    //プレイヤーのTransform
    public Transform player;


    private void Start()
    {

        cam = GameObject.Find("PlayerCamera");

        Cursor.lockState = CursorLockMode.Locked;


        play = GameObject.Find("Player2");

        //// MainCamera(自分自身)とplayerとの相対距離を求める
        //offset = transform.position - player.transform.position;


    }

    private void Update()
    {

        //右スティックの挙動
        RightStick();


    }

    //右スティックの挙動
    void RightStick()
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
