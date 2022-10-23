using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObject : MonoBehaviour
{
    public GameObject gameManager;
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
            gameManager.GetComponent<ItemDisplay>().showItem(gameObject.name);
            if (gameObject.name == "feet"){
                KeyManager.FoundKey(0);
            }
            else if (gameObject.name == "flower"){
                KeyManager.FoundKey(1);
            }
            else if (gameObject.name == "feather"){
                KeyManager.FoundKey(2);
            }
            else if (gameObject.name == "urn"){
                KeyManager.FoundKey(3);
            }
            Debug.Log(gameObject.name + " picked up");
            gameObject.SetActive(false);
        }
    }

}
