using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using static KeyManager;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameFinish;

    GameObject gameOverFailUI;
    GameOver goScript;
    GameObject gameOverSuccessUI;
    GameOverSuccess gosScript;

    public bool gameEnded;

    bool broadcastedGameFinish;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "GameScene"){
            gameOverFailUI = GameObject.FindGameObjectWithTag("GameOver");
        goScript = gameOverFailUI.GetComponent<GameOver>();
        gameOverSuccessUI = GameObject.FindGameObjectWithTag("GameOverSuccess");
        gosScript = gameOverSuccessUI.GetComponent<GameOverSuccess>();

        }
        
        gameEnded = false;
        gameOverFailUI.SetActive(false);
        gameOverSuccessUI.SetActive(false);

        broadcastedGameFinish = false;   
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameScene" && KeyManager.FoundAll())
        {
            //trying to broadcast the event once
            if (!broadcastedGameFinish)
            {
                Debug.Log("Game success");
                broadcastedGameFinish = true;
                GameWon();
            }
        }
    }

    public void GameReset()
    {
        SceneManager.LoadSceneAsync("GameScene");
        Debug.Log("Reset");
    }

    public void GoToMenu()
    {
        SceneManager.LoadSceneAsync("StartScreen");
    }

    public void IntroCutScenes(){

    }

    public void QuitGame(){
        Application.Quit();
    }

    public void GoToControls(){
        SceneManager.LoadSceneAsync("ControlsScene");
    }

    public void GoToCredits(){
        SceneManager.LoadSceneAsync("CreditsScene");
    }


    public void GameWon()
    {
        if (!gameEnded)
        {
            gameOverSuccessUI.SetActive(true);
            gosScript.OnGameOver();
            gameEnded = true;
        }
    }
    public void GameLost()
    {
        if (!gameEnded)
        {
            gameOverFailUI.SetActive(true);
            goScript.OnGameOver();
            gameEnded = true;
        }
    }
}
