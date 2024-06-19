using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttack : MonoBehaviour
{
    public float attackDurationRate;
    public AudioClip knifeSlash;
    public AudioSource src;
    private PlayerKeyBindings playerKeyBindings;
    private float lastTimeFired;
    private Animator animator;
    public bool isAttacking;
    
    void Start()
    {
        playerKeyBindings = PlayerKeyBindings.GetInstance();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        OnFire();
    }


    private void OnFire() 
    {
        if(Input.GetKey(playerKeyBindings.attack))
        {
            float timeSinceLastFire = Time.time - lastTimeFired;

            if(timeSinceLastFire >= attackDurationRate) 
            {
                animator.SetBool("IsShootTriggered", true);
                lastTimeFired = Time.time;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<IsHitable>()) 
        {
            if(collision.GetComponent<IsHitable>().shouldBeDestroyed && isAttacking)
            {
                Destroy(collision.gameObject);
                CoinsController.instance.UpdateCoins(100);
            }
        }
    }
}
