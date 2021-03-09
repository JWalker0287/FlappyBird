using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float speed = 10;
    Camera gameCam;
    void Start()
    {
        gameCam = Camera.main;
    }

    void Update()
    {
        if (GameManager.gameState != GameState.Playing) return;

        transform.position += Vector3.left * speed * Time.deltaTime;

        Vector3 view = gameCam.WorldToViewportPoint(transform.position);
        if (view.x < -0.1f) 
        {
            view.y = Random.Range(0.2f,0.8f);
            view.x = 1.1f;
        }
        transform.position = gameCam.ViewportToWorldPoint(view);
    }
}
