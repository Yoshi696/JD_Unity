using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    private void Start()
    {

    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            if (Input.GetButtonDown("Cont_Jump") || Input.GetKeyDown("space")) //Aボタンを押したら開始
            {
                SceneManager.LoadScene("MainGame");//ゲーム開始
                
                Debug.Log(1);

            }
        }
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            Debug.Log(1);
            if (Input.GetButtonDown("Cont_Jump") || Input.GetKeyDown("space")) //Aボタンを押したら開始
            {
                //GameObject.Find("Player2").transform.position = new Vector3(48.06f, 1.56f, -45.1f);
                SceneManager.LoadScene("Start");//ゲームタイトル
            }
        }
        if (SceneManager.GetActiveScene().name == "Clear")
        {
            //GameObject.Find("Player2").transform.position = new Vector3(pos1.x+5, pos1.y + 40, pos1.z+5);
            if (Input.GetButtonDown("Cont_Jump") || Input.GetKeyDown("space")) //Aボタンを押したら開始
            {
                //  Destroy(this);
                //GameObject.Find("Player2").transform.position = new Vector3(48.06f, 1.56f, -45.1f);
                SceneManager.LoadScene("Start");//ゲームタイトル
            }
        }
    }
}
