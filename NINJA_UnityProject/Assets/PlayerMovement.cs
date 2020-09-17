using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    //プレイヤーの移動関連
    public float speed = 0.5f;          //移動速度
    public float acceleration = 0;      //加速度

    //スクリプト関連
    public CamSystem cs;                //カメラ
    public Rigidbody rb;                //プレイヤーのRigitBody
    
    //ジャンプ関連
    public bool isJump = false;         //ジャンプのフラグ
    public float JumpForce = 100.0f;    //ジャンプ力

    //壁キック関連
    public bool isWall = false;     //壁キック
    public float WallJumpForce = 0f;    //壁キックの力

    //ターンフラグ
    public bool RightTurnFlg = false;   //右90°ターン
    public bool LeftTurnFlg = false;    //左90°ターン

    private void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            acceleration += 0.002f;
            if (acceleration > 0.05f) acceleration = 0.5f;
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

        //壁キックの処理
        Player_Wall_Jump();

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
        if (other.gameObject.tag == "Wall") {
            isWall = true;
        }

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Wall") {
            isWall = false;
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

    //壁キック
    void Player_Wall_Jump() {

        if (isJump == true && isWall == true && Input.GetButton("Cont_Jump") == true) {
            
            rb.velocity = Vector3.up * JumpForce;
            cs.Turn_Vec = -1;
            cs.Turn_Angle = 180f;
            isWall = false;
        }

    }

    //直角に曲がる処理
    void Player_Turn() {

        if (Input.GetButton("Cont_R1") == true && RightTurnFlg == false && !isJump)
        {
            cs.Turn_Vec = -1;
            cs.Turn_Angle = 90f;
            RightTurnFlg = true;
        }
        if (Input.GetButton("Cont_R1") == false)
            RightTurnFlg = false;

        if (Input.GetButton("Cont_L1") == true && LeftTurnFlg == false && !isJump)
        {
            cs.Turn_Vec = 1;
            cs.Turn_Angle = 90f;
            LeftTurnFlg = true;
        }
        if (Input.GetButton("Cont_L1") == false)
            LeftTurnFlg = false;
        
    }

    //反射時に一定時間だけ処理を止める
    //IEnumerator WaitKeyInput() {

    //    this.gameObject.GetComponent<PlayerMovement>().enabled = false;
    //    {
    //        yield return new WaitForSeconds(0.5f);
    //    }
    //    this.gameObject.GetComponent<PlayerMovement>().enabled = true;

    //}

    
}
