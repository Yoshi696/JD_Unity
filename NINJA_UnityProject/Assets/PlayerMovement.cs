using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 0.5f;
    public float acceleration = 0;
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

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bumper") {
            StartCoroutine("WaitKeyInput");
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
