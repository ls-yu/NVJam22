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

    [SerializeField]
    GameObject gameOverFailUI;
    GameOver goScript;

    bool broadcastedGameFinish;

    void Start()
    {
        gameOverFailUI = GameObject.FindGameObjectWithTag("GameOver");
        goScript = gameOverFailUI.GetComponent<GameOver>();
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
                StartCoroutine(GameWon());
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

    IEnumerator GameWon(){
        yield return new WaitForSeconds(0.3f);
        // TODO play success sound
        SceneManager.LoadSceneAsync("GameOverSuccess");
    }

    /*
    public void GameWon()
    {

    }
    */

    public void GameLost()
    {
        goScript.OnGameOver();
    }
}
