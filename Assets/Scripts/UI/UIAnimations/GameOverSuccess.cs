using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSuccess : MonoBehaviour
{
    Transform item1, item2, item3, item4;
    Transform retryButton;
    Transform menuButton;

    Animator anim;

    bool animationFinished;

    void Start()
    {
        item1 = transform.Find("Item1");
        item2 = transform.Find("Item2");
        item3 = transform.Find("Item3");
        item4 = transform.Find("Item4");
        retryButton = transform.Find("RetryButton");
        menuButton = transform.Find("MenuButton");
        item1.gameObject.SetActive(false);
        item2.gameObject.SetActive(false);
        item3.gameObject.SetActive(false);
        item4.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);

        anim = GetComponent<Animator>();

        animationFinished = false;
    }

    void Update()
    {

        if (animationFinished)
        {
            retryButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
        }
        else
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.GameOverUISuccessEnd"))
            {
                animationFinished = true;
            }
        }
    }

    public void OnGameOver()
    {
        anim.SetTrigger("GameOver");
        item1.gameObject.SetActive(true);
        item2.gameObject.SetActive(true);
        item3.gameObject.SetActive(true);
        item4.gameObject.SetActive(true);
    }
}
