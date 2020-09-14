using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    //private GameObject Camera2;
    public GameObject sphe;
    public GameObject camera;
    public GameObject play2;

    void OnCollisionEnter(Collision other)
    {
       // Vector3 cam3 = Camera2.transform.position;

        if (other.gameObject.tag == "Player")
        {
            play2.GetComponent<PlayerMovement>().enabled = false;
            camera.GetComponent<Camera>().enabled = false;
            Destroy(sphe);
        }
    }
}
