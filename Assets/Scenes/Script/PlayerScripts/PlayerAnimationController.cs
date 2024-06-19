using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerControl playerControl;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerControl = GetComponent<PlayerControl>();
    }

    void Update()
    {
        CastAnimation();
    }

    void CastAnimation() 
    {
        if(playerControl.isMoving)
        {
            animator.SetFloat("MoveX", playerControl.moveDirection.x);
            animator.SetFloat("MoveY", playerControl.moveDirection.y);
        }
        animator.SetBool("isMoving", playerControl.isMoving);
    }
}
