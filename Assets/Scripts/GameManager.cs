using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum GameState
{
    Ready,
    Playing,
    Ended
};

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Ready;
    public RawImage background, platform;

    public float parallaxSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.setAnimation("Reposo");

    }

    // Update is called once per frame
    void Update()
    {
        
        bool action = Input.GetKey(KeyCode.Return); //Usar el enter
        updateGameState(action);
        handleJump();
        handlePunch();
        HandleCollisions();
        updateFondo();
    }

    void updateGameState(bool estado)
    {
        if (estado == true && gameState == GameState.Ready)
        {
            gameState = GameState.Playing;
            PlayerManager.Instance.setAnimation("Correr");
            SpawnManager.Instance.StartSpawn();
        }
    }

    void handleJump()
    {
        bool action = Input.GetKeyDown("space");
        if (action == true && gameState == GameState.Playing)
        {
            PlayerManager.Instance.setAnimation("Saltar");
            

        }
    }
    void handlePunch()
    {
        bool action = Input.GetKey(KeyCode.C);
        if (action == true && gameState == GameState.Playing)
        {
            PlayerManager.Instance.setAnimation("Golpear");
           

        }
    }
    void updateFondo()
    {
        if (gameState == GameState.Playing)
        {
            float finalSpeed = parallaxSpeed * Time.deltaTime;
            background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
            platform.uvRect = new Rect(platform.uvRect.x + finalSpeed, 0f, 1f, 1f);

        }
    }
    void HandleCollisions()
    {
        if (gameState == GameState.Playing && PlayerManager.Instance.enemyCollision)
        {
            gameState = GameState.Ended;
            PlayerManager.Instance.setAnimation("Morir");
            SpawnManager.Instance.StopSpawn();
            //SpeedManager.Instance.ResetSpeed();
        }
    }
}
