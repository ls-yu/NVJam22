using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameFinish;

    bool broadcastedGameFinish;

    void Start()
    {
        broadcastedGameFinish = false;   
    }

    void Update()
    {
        if (KeyManager.FoundAll())
        {
            //trying to broadcast the event once
            if (!broadcastedGameFinish)
            {
                OnGameFinish();
                broadcastedGameFinish = true;
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
        Debug.Log("Menu");
    }

}
