using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{

    [System.Serializable]
    public struct FrameArg {
        public Sprite frameSprite;
        public float activeTime;

        public AudioClip audioClip;
    }

    public struct Frame {
        public GameObject obj;
        public float activeTime;

        public AudioClip audioClip;

        public Frame(GameObject obj, float activeTime, AudioClip audioClip){
            this.obj = obj;
            this.activeTime = activeTime;
            this.audioClip = audioClip;
        }
    }

    public FrameArg[] frameArgs;
    List<Frame> frames = new List<Frame>();

    IEnumerator Fade(SpriteRenderer spriteRenderer)
    {
        Color c = spriteRenderer.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.01f)
        {
            c.a = alpha;
            spriteRenderer.color = c;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Cutscenes()
    {
        foreach(Frame frame in frames){
            if(frame.audioClip != null){
                audioSource.clip = frame.audioClip;
                audioSource.Play();
            }
            
            yield return new WaitForSeconds(frame.activeTime);
            yield return StartCoroutine(Fade(frame.obj.GetComponent<SpriteRenderer>()));
        }

        // Load menu
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }



    // Start is called before the first frame update
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Initialize sprite objects
        for(int i = 0; i < frameArgs.Length; i++){
            GameObject frameObj = new GameObject("Frame " + i.ToString());
            frameObj.AddComponent<SpriteRenderer>();
            frameObj.GetComponent<SpriteRenderer>().sprite = frameArgs[i].frameSprite;
            frameObj.GetComponent<SpriteRenderer>().sortingOrder = frameArgs.Length - i;
            frames.Add(new Frame(frameObj, frameArgs[i].activeTime, frameArgs[i].audioClip));
        }

        // Play Couroutine
        StartCoroutine(Cutscenes());
    }
}
