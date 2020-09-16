using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    //public GameObject camera;
    //public GameObject play2;
    //private Vector3 pos1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
         //   pos1 = GameObject.Find("Player2").transform.position;
            //play2.GetComponent<PlayerMovement>().enabled = false;
            //camera.GetComponent<Camera>().enabled = false;
            SceneManager.LoadScene("Clear");//ゲームクリア
        }
    }

private void Update()
{
    //if (SceneManager.GetActiveScene().name == "Clear")
    //{
    //    //GameObject.Find("Player2").transform.position = new Vector3(pos1.x+5, pos1.y + 40, pos1.z+5);
    //    if (Input.GetButtonDown("Cont_Jump") || Input.GetKeyDown("space")) //Aボタンを押したら開始
    //    {
    //          //  Destroy(this);
    //            SceneManager.LoadScene("Start");//ゲームタイトル
    //    }
    //}
}
}
