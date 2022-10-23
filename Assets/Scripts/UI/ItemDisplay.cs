using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Image[] itemImages; //order: feet, petal, feather, urn
    bool feet;
    bool flower;
    bool feather;
    bool urn;

    public void showItem(String item)
    {
        switch(item)
        {
            case "feet":
                itemImages[0].gameObject.SetActive(true);
                break;

            case "flower":
                itemImages[1].gameObject.SetActive(true);
                break;

            case "feather":
                itemImages[2].gameObject.SetActive(false);
                break;

            case "urn":
                itemImages[3].gameObject.SetActive(false);
                break;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        feet = true;
        petal = true;
        feather = true;
        urn = true;

        foreach(Image img in itemImages)
        {
            img.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
