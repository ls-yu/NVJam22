using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    IEnumerator delete(float timeToLive){
        yield return new WaitForSeconds(timeToLive);
    }
    void Start()
    {
        StartCoroutine(delete(GetComponent<AudioSource>().clip.length));
    }
}
