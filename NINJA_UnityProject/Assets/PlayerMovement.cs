using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 0.5f;
    public float acceleration = 0;


    //プレイヤーのRigitBody
    public Rigidbody rb;

    //ジャンプ力
    public float JumpForce = 100.0f;

    //ジャンプのフラグ
    public bool isJump = false;

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

    IEnumerator WaitKeyInput() {

        this.gameObject.GetComponent<PlayerMovement>().enabled = false;
        {
            yield return new WaitForSeconds(0.5f);
        }
        this.gameObject.GetComponent<PlayerMovement>().enabled = true;

    }

    
}
