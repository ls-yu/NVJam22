using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public GameObject[] itemImages; 

    public void showItem(string item)
    {
        switch(item)
        {
            case "feet":
                itemImages[0].SetActive(true);
                break;

            case "flower":
                itemImages[1].SetActive(true);
                break;

            case "feather":
                itemImages[2].SetActive(true);
                break;

            case "urn":
                itemImages[3].SetActive(true);
                break;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        /*
        feet = true;
        flower = true;
        feather = true;
        urn = true;

        foreach(Image img in itemImages)
        {
            img.gameObject.SetActive(false);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
