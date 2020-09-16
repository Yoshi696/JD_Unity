using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 0.5f;
    public float acceleration = 0;
<<<<<<< HEAD
=======

    //カメラのスクリプト
    public CamSystem cs;

    //プレイヤーのRigitBody
    public Rigidbody rb;

    //ジャンプ力
    public float JumpForce = 100.0f;

    //ジャンプのフラグ
    public bool isJump = false;

    //ターンフラグ
    public bool RightTurnFlg = false;
    public bool LeftTurnFlg = false;

>>>>>>> 96753de21c34fd0ae6b5cb16a70f40c055bc24d4
    private void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            acceleration += 0.002f;
            if (acceleration > 0.5f) acceleration = 0.5f;
        }
        else
        {
            acceleration -= 0.005f;
            if (acceleration < 0) acceleration = 0;
        }
        var pos = transform.position;
        pos += transform.right * Input.GetAxis("Horizontal") * speed;
        pos += transform.forward * Input.GetAxis("Vertical") * (speed + acceleration);
        transform.position = pos;

        //ジャンプの挙動
        Player_Jump();

        //直角に曲がる処理
        Player_Turn();
    }

    //オブジェクトに触れたら発動
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bumper") {
            StartCoroutine("WaitKeyInput");
        }
        if (other.gameObject.tag == "Roads")
        {
            isJump = false;
        }

    }

    //ジャンプの挙動
    void Player_Jump()
    {
        if (Input.GetButton("Cont_Jump") == true && isJump == false)
        {
            //play.GetComponent<Rigidbody>().AddForce(0f, JumpForce, 0f);
            rb.velocity = Vector3.up * JumpForce;
            isJump = true;
        }
    }

    //直角に曲がる処理
    void Player_Turn() {
        if (Input.GetButton("Cont_R1") == true && RightTurnFlg == false && !isJump)
        {
            cs.Turn_Vec = -1;
            RightTurnFlg = true;
        }
        if (Input.GetButton("Cont_R1") == false)
            RightTurnFlg = false;

        if (Input.GetButton("Cont_L1") == true && LeftTurnFlg == false && !isJump)
        {
            cs.Turn_Vec = 1;
            LeftTurnFlg = true;
        }
        if (Input.GetButton("Cont_L1") == false)
            LeftTurnFlg = false;
        
    }

    IEnumerator WaitKeyInput() {

        this.gameObject.GetComponent<PlayerMovement>().enabled = false;
        {
            yield return new WaitForSeconds(0.5f);
        }
        this.gameObject.GetComponent<PlayerMovement>().enabled = true;

    }

    
}
