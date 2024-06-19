using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKnifeAttack : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       GameObject knifeObject = animator.gameObject;
       WeaponRotationController controller = knifeObject.GetComponent<WeaponRotationController>();
       KnifeAttack knifeAttack = knifeObject.GetComponent<KnifeAttack>();
       knifeAttack.isAttacking = true;
       controller.blockWeaponRotation = true;
       animator.SetBool("IsShootTriggered", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       GameObject knifeObject = animator.gameObject;
       WeaponRotationController controller = knifeObject.GetComponent<WeaponRotationController>();
       KnifeAttack knifeAttack = knifeObject.GetComponent<KnifeAttack>();
       knifeAttack.isAttacking = false;
       controller.blockWeaponRotation = false;
    }
}
