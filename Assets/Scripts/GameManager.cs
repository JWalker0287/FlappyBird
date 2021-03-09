using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Waiting,
    Playing,
    Ended
}
public class GameManager : MonoBehaviour
{
    public float gravity = -25;
    public static GameState gameState = GameState.Waiting;
    public GameObject menu;

    void Start ()
    {
        Physics.gravity = Vector3.zero;
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

    }
    public static void EndGame()
    {
        gameState = GameState.Ended;
    }
}
