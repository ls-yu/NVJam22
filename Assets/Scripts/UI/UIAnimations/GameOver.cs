using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    Transform deadduck;
    Transform retryButton;
    Transform menuButton;

    Animator anim;

    bool animationFinished;

    void Start()
    {
        deadduck = transform.Find("DeadDuck");
        retryButton = transform.Find("RetryButton");
        menuButton = transform.Find("MenuButton");
        deadduck.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);

        anim = GetComponent<Animator>();

        animationFinished = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnGameOver();
        }

        if (animationFinished)
        {
            retryButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
        }
        else
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.ShowText"))
            {
                animationFinished = true;
            }
        }
    }

    public void OnGameOver()
    {
        anim.SetTrigger("GameOver");
        deadduck.gameObject.SetActive(true);
    }
}
