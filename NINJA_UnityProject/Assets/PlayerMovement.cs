using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 0.5f;
    public float acceleration = 0;

    //カメラのスクリプト
    public CamSystem cs;

    //プレイヤーのRigitBody
    public Rigidbody rb;

    //ジャンプ力
    public float JumpForce = 100.0f;

    //ジャンプのフラグ
    public bool isJump = false;

    //壁ジャンプのフラグ
    public bool isWallJump = false;

    //ターンフラグ
    public bool RightTurnFlg = false;
    public bool LeftTurnFlg = false;

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

    //オブジェクトから離れたら発動
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "wall")
        {
            isWallJump = false;
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

        if (Input.GetButton("Cont_Jump") == true && isJump == true && isWallJump == false)      //壁ジャンプ
        {
            //play.GetComponent<Rigidbody>().AddForce(0f, JumpForce, 0f);
            rb.velocity = Vector3.up * JumpForce;
            isWallJump = true;
            cs.Turn_Vec = 2;
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
