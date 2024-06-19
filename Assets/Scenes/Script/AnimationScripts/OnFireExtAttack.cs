using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFireExtAttack : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       GameObject fireExtObject = animator.gameObject;
       animator.SetBool("IsShootTriggered", false);
    }
}
