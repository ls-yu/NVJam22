using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera cam;

    public GameObject player;
    public GameObject right;
    public GameObject left;
    public GameObject top;
    public GameObject bottom;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        Vector2 bottomLeftOfScreen = cam.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 topRightOfScreen = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenSizeInWorld = topRightOfScreen - bottomLeftOfScreen;
        if (bottomLeftOfScreen.x < left.transform.position.x ){
            transform.position = new Vector3(left.transform.position.x + screenSizeInWorld.x / 2, transform.position.y,-10);
        }
        if (topRightOfScreen.x > right.transform.position.x){
            transform.position = new Vector3(right.transform.position.x - screenSizeInWorld.x / 2, transform.position.y, -10);
        }
        if (topRightOfScreen.y > top.transform.position.y ){
            transform.position = new Vector3(transform.position.x, top.transform.position.y - screenSizeInWorld.y / 2, -10);
        }
        if (bottomLeftOfScreen.y < bottom.transform.position.y){
            transform.position = new Vector3(transform.position.x, bottom.transform.position.y + screenSizeInWorld.y / 2, -10);
        }
        Debug.Log(transform.position);
        Debug.Log(player.transform.position);
    }
}
