using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerTester : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.OnGameFinish += PrintFinish;
    }

    private void OnDisable()
    {
        GameManager.OnGameFinish -= PrintFinish;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            KeyManager.FoundKey(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            KeyManager.FoundKey(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            KeyManager.FoundKey(3);
        }
    }

    void PrintFinish()
    {
        Debug.Log("Found All Keys!");
    }
}
