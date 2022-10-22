using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool isAwake = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAwake){
            Move();
        }
    }

    void WakeUp(){
        isAwake = true;
        
    }

    void Move(){

    }
}
