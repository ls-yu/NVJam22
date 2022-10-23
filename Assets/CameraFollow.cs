using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject right;
    public GameObject left;
    public GameObject top;
    public GameObject bottom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        /*
        if (transform.position.x < left.transform.position.x + Screen.width/2 ){
            transform.position = new Vector3(left.transform.position.x + Screen.width/2, transform.position.y,-10);
        }
        if (transform.position.x > right.transform.position.x - Screen.width/2){
            transform.position = new Vector3(right.transform.position.x - Screen.width/2, transform.position.y, -10);
        }
        if (transform.position.y > top.transform.position.x - Screen.height/2){
            transform.position = new Vector3(transform.position.x, top.transform.position.y - Screen.height/2, -10);
        }
        if (transform.position.y < bottom.transform.position.x + Screen.height/2){
            transform.position = new Vector3(transform.position.x, bottom.transform.position.y + Screen.height/2, -10);
        }
        Debug.Log(transform.position);
        Debug.Log(player.transform.position);
        */
    }
}
