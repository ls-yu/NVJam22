using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip gameClip;
    public AudioClip flyMeToTheMoon;
    public AudioClip flyMeToTheMoon2;

    GameManager gm;

    bool startedEndSong = false;
    bool startedLoopingEnd;
    bool finishedIntro;

    AudioSource audioSource;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameClip;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gm.gameEnded);
        if (gm.gameEnded)
        {
            if (!startedEndSong)
            {
                audioSource.clip = flyMeToTheMoon;
                audioSource.loop = false;
                audioSource.Play();
                startedEndSong = true;
            }
            else
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = flyMeToTheMoon2;
                    audioSource.loop = true;
                    audioSource.Play();
                }
            }
        }
    }
}
