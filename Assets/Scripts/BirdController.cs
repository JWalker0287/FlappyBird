using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpHeight = 2;
    public AudioClip deathSound;
    Rigidbody body;
    AudioSource sfx;
    //Animator anim;
    void Start()
    {
        //anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        sfx = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameManager.gameState != GameState.Ended&&Input.GetButtonDown("Jump"))
        {
            float jumpSpeed = Mathf.Sqrt(2 * jumpHeight * -Physics.gravity.y);
            body.velocity = Vector2.up * jumpSpeed;
            sfx.Play();
            //anim.SetTrigger("flap");
        }
        transform.right = new Vector3(1, body.velocity.y, 0);
    }
    void OnCollisionEnter()
    {
        sfx.clip = deathSound;
        sfx.Play();
        GameManager.EndGame();
    }
}
