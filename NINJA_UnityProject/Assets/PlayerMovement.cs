using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 0.5f;

    private void FixedUpdate()
    {
        var pos = transform.position;
        pos += transform.right * Input.GetAxis("Horizontal") * speed;
        pos += transform.forward * Input.GetAxis("Vertical") * speed;
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
