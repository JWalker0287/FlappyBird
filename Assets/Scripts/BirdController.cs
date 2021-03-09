using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpHeight = 2;
    public AudioClip deathSound;
    Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            float jumpSpeed = Mathf.Sqrt(2 * jumpHeight * -Physics.gravity.y);
            body.velocity = Vector2.up * jumpSpeed;
        }
        transform.right = new Vector3(1, body.velocity.y, 0);
    }
}
