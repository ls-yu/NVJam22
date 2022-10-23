using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;
    Camera maincam;

    public GameObject flashlight;
    LightScript lightScript;
    public float maxAngle;
    public float minAngle;
    public float angleChangeSpeed;

    bool isLightOff = false;


    void Start()
    {
        lightScript = flashlight.GetComponent<LightScript>();
        maincam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        body = GetComponent<Rigidbody2D>(); 
    }

    void Update ()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Light beam adjustment
        if(Input.GetKey(KeyCode.Q)){
            lightScript.angle += angleChangeSpeed * Time.deltaTime;
        } 

        if(Input.GetKey(KeyCode.E)){
            lightScript.angle -= angleChangeSpeed * Time.deltaTime;
        }

        lightScript.angle  = Mathf.Clamp(lightScript.angle, minAngle, maxAngle);


        // Light toggling
        if(Input.GetKeyDown(KeyCode.F)){
            if(isLightOff){
                flashlight.SetActive(true);
            } else {
                flashlight.SetActive(false);
            }
            isLightOff = !isLightOff;
        }
    }

    private void FixedUpdate()
    {  

        // Movement
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        // Look at mouse
        Vector2 mousePos = maincam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currPos = transform.position;
        Vector2 dir = mousePos - currPos;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y , dir.x) * 180 / Mathf.PI);
    }
}
