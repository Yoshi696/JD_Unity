using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bounce : MonoBehaviour
{
    public float bounce = 10.0f;

    private Transform player;

    Quaternion OrigAng;

    private void Start()
    {
        player = GameObject.Find("Player2").GetComponent<Transform>();
        OrigAng = player.rotation;
        
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                Vector3 norm = other.contacts[0].normal;
                Vector3 vel = other.rigidbody.velocity.normalized;
                vel += new Vector3(-norm.x * 2, 0f, -norm.z * 2);
                //vel += Vector3.Reflect(norm, vel);
                other.rigidbody.AddForce(vel * bounce, ForceMode.Impulse);
                player.Rotate(norm);
                break;
        }
    }
}
