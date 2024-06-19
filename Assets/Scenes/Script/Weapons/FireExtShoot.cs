using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtShoot : MonoBehaviour
{
    [Header("Shot properties")]
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private int bulletsPerShot;
    [SerializeField]
    private float fireRateDuration;
    [SerializeField]
    private float spreadRate;

    [Header("General")]
    [SerializeField]
    private GameObject bulletObject;
    [SerializeField]
    private Animator particlesAnimator;
    [SerializeField]
    private Transform gunOffset;

    [Header("Audio")]
    [SerializeField]
    private AudioClip audioShot;
    [SerializeField]
    private AudioSource audioSource;

    private PlayerKeyBindings playerKeyBindings;
    private float lastTimeFired;

    void Start()
    {
        playerKeyBindings = PlayerKeyBindings.GetInstance();
    }

    void Update()
    {
        OnFire();
    }

    private void OnFire()
    {

        if (Input.GetKey(playerKeyBindings.attack))
        {
            float timeSinceLastFire = Time.time - lastTimeFired;

            if (timeSinceLastFire >= fireRateDuration)
            {
                FireBullet();
                particlesAnimator.SetBool("IsShootTriggered", true);
                lastTimeFired = Time.time;
            }
        }
    }

    private void FireBullet()
    {
        for (int i = 0; bulletsPerShot > i ; i++)
        {
            createBullet(spreadRate);
        }
    }


    private void createBullet(float randomVectorRate)
    {
        GameObject bullet = Instantiate(bulletObject, gunOffset.position, transform.rotation);
        Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();

        Vector3 spreadVector = new Vector3(
            Random.Range(-randomVectorRate, randomVectorRate),
            Random.Range(-randomVectorRate, randomVectorRate),
            0
            );

        bulletRigidBody.velocity = bulletSpeed * (transform.up + spreadVector);
    }
}
