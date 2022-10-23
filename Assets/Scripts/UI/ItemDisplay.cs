using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Image[] itemImages; //order: feet, petal, feather, urn
    bool feet;
    bool petal;
    bool feather;
    bool urn;


    // Start is called before the first frame update
    void Start()
    {
        feet = true;
        petal = true;
        feather = true;
        urn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //need to check if item is obtained


        //shows all items
        foreach(Image img in itemImages)
        {
            img.gameObject.SetActive(true);
        }

        itemImages[2].gameObject.SetActive(false);

        //Debug.Log("game over!)
    }
}
