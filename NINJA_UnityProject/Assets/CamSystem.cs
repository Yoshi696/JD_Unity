using System;
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

    //カメラの回転アングル
    public float xRot = 0f;

    //プレイヤーの向き
    private GameObject play;   //プレイヤー情報格納用
    private Vector3 offset;    //相対距離取得用

    //プレイヤーのTransform
    public Transform player;
    public float mouseX;
    public float mouseY;
    public float ContX;
    public float ContY;
    public int Turn_Vec = 0;
    public float Turn_Angle = 0;

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

        //mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        //mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        //ContX = Input.GetAxis("R_Stick_H") * ContSensitivity * Time.deltaTime;
        //ContY = Input.GetAxis("R_Stick_V") * ContSensitivity * Time.deltaTime;
        //Turn_Angle = Turn_Angle * ContSensitivity * Time.deltaTime;

        mouseX = 0 * Sensitivity * Time.deltaTime;
        mouseY = 0 * Sensitivity * Time.deltaTime;
        ContX = 0 * ContSensitivity * Time.deltaTime;
        ContY = 0 * ContSensitivity * Time.deltaTime;


        if (Turn_Vec != 0) {
            ContX = Turn_Vec * Turn_Angle;
        }



        if (!ControllerFlg) xRot -= mouseY;
        else xRot -= ContY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);


        cam.transform.localRotation = Quaternion.Euler(xRot, Turn_Angle, 0f);

        player.Rotate(Vector3.up * mouseX);
        player.Rotate(Vector3.up * ContX);

        Turn_Vec = 0;
        Turn_Angle = 0;
    }

}
