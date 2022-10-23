using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGif : MonoBehaviour
{
    public float rate = 0.08f;
    public float timer = 0.0f;
    public Sprite[] imgs;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > rate){
            timer = 0.0f;
            GetComponent<Image>().sprite = imgs[index];
            index++;
            if (index > 17){
                index = 0;
            }
        }
    }

    
}
