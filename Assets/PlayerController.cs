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
    void Start()
    {
        maincam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        body = GetComponent<Rigidbody2D>(); 
    }

    void Update ()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
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
