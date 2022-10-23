using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUI : MonoBehaviour
{
    //public bool petal, urn, webbedFeet, feather;
    private int health = 5;
    public Text healthText;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH : " + health;

        if(Input.GetKeyDown(KeyCode.Space)){
            health--;
        }
        
    }
}
