using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
public class AnimationScriptController : MonoBehaviour
{
    Animator animator;
    NavigationRound nav;
    private void Start()
    {
        animator = GetComponent<Animator>();
        nav = GetComponent<NavigationRound>();

    }


    void Update()
    {   
        if (nav != null && animator != null)
        {
            animator.SetBool("isWalking", !nav.IsWaiting);
            if (nav.isEnemy)
            {
                animator.SetInteger("randomIdle", nav.RandomIdle);
                animator.SetBool("isLooking", nav.IsLooking);
                animator.SetBool("isRunning", nav.IsRunning);
            }
        }
    }
}
