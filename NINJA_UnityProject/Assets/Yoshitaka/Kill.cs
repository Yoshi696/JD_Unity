using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    //private GameObject Camera2;
    //public GameObject sphe;
    //public GameObject camera;
    //public GameObject play2;
   // private Vector3 pos1;

    private void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
       // Vector3 cam3 = Camera2.transform.position;

        if (other.gameObject.tag == "Player")
        {
            //play2.GetComponent<PlayerMovement>().enabled = false;
            //camera.GetComponent<Camera>().enabled = false;
            //Destroy(sphe);
            //pos1 = GameObject.Find("Player2").transform.position;
            //Debug.Log(pos1);
            SceneManager.LoadScene("GameOver");//ゲームオーバー
        }
    }

    public void Update()
    {
        //if (SceneManager.GetActiveScene().name == "GameOver")
        //{
        //    if (Input.GetButtonDown("Cont_Jump") || Input.GetKeyDown("space")) //Aボタンを押したら開始
        //    {
        //        //  Destroy(Player2);
        //        Debug.Log(1);
        //        SceneManager.LoadScene("Title");//ゲームタイトル
        //    }
        //}
    }
}
