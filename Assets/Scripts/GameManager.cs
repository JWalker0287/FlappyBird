using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Waiting,
    Playing,
    Ended
}
public class GameManager : MonoBehaviour
{
    public float gravity = -25;
    public static GameManager instance;
    public static int points = 0;
    public static GameState gameState = GameState.Waiting;
    public GameObject menu;
    public Text scoreText;
    public Animator background1;
    public Animator background2;

    void Start ()
    {
        instance = this;
        Physics.gravity = Vector3.zero;
        points = 0;
        scoreText.text = points.ToString();
    }
    void Update()
    {
        if (gameState == GameState.Waiting && Input.GetButtonDown("Jump")) 
        {
            menu.SetActive(false);
            gameState = GameState.Playing;
            Physics.gravity = Vector3.up * gravity;
        }
        if (gameState == GameState.Ended && Input.GetButtonDown("Jump"))
        {
            gameState = GameState.Waiting;
            SceneManager.LoadScene("FlappyBird");
        }

        scoreText.text = points.ToString();
    }
    public static void AddPoint()
    {
        points ++;
        Debug.Log(points);
    }
    public static void EndGame()
    {
        gameState = GameState.Ended;
        instance.background1.speed = 0;
        instance.background2.speed = 0;
    }
}
