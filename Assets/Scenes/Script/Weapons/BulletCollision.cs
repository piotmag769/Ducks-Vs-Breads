using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private Animator animator;
    public AudioSource src;
    public AudioClip deathClip;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IsHitable>()) 
        {
            animator.SetBool("IsObjectHit", true);
            if(collision.GetComponent<IsHitable>().shouldBeDestroyed)
            {
                Destroy(collision.gameObject);
                CoinsController.instance.UpdateCoins(100);
                src.PlayOneShot(deathClip);
            }
        }
    }
}
