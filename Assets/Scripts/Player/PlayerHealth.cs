using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage){
        health-=damage;
        if (health <= 0){
            SceneManager.LoadSceneAsync("GameOverFailure");
        }
    }

    public int GetHealth(){
        return health;
    }

    
}
