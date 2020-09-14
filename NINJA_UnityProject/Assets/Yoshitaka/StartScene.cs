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
        if (Input.GetButtonDown("Cont_Jump")) //Aボタンを押したら開始
        {
            SceneManager.LoadScene("MainGame");//ゲーム開始
        }
    }
}
