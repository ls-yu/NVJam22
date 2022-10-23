using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    public float minSpeed;
    public GameObject targetBody;
    
    Rigidbody2D targetRigidbody;
    AudioSource audioSource;
    void Start(){
        targetRigidbody = targetBody.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(targetRigidbody.velocity.magnitude > minSpeed){
            audioSource.UnPause();
        } else {
            audioSource.Pause();
        }
    }
}
