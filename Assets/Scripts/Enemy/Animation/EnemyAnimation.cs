using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void WakeUpAnimation()
    {
        anim.SetTrigger("IsAwake");
    }

    public void AttackAnimation(){
        anim.SetTrigger("Attack");
    }

    public void TakeDamageAnimation()
    {
        anim.SetTrigger("TakeDamage");
    }

    public void DeathAnimation()
    {
        anim.SetTrigger("Death");
    }
}
