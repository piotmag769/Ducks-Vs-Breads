using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBreadAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerAwarenessController targetDirectionController;

    void Awake()
    {
        animator = GetComponent<Animator>();
        targetDirectionController = GetComponent<PlayerAwarenessController>();
    }

    void Update()
    {
        CastAnimation();
    }

    void CastAnimation() 
    {
        animator.SetFloat("moveX",targetDirectionController.directionToPlayer.x);
        animator.SetFloat("moveY",targetDirectionController.directionToPlayer.y);
        if(targetDirectionController.directionToPlayer.magnitude > Mathf.Epsilon)
        {
            animator.SetBool("isMoving", true);
        } 
        else 
        {
            animator.SetBool("isMoving", false);
        }
    }
}
