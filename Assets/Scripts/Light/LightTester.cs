using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LightTester : MonoBehaviour
{
    Camera maincam;
    void Start()
    {
        maincam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (Vector3) new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * 3 * Time.deltaTime;

        Vector2 mousePos = maincam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currPos = transform.position;
        Vector2 dir = mousePos - currPos;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y , dir.x) * 180 / Mathf.PI);
    }
}
