using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObject : MonoBehaviour
{
    GameObject itemDisplay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "player"){
            itemDisplay.GetComponent<ItemDisplay>().showItem(gameObject.name);
        }
        gameObject.SetActive(false);
    }    

}
