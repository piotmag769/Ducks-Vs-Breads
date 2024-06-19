using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunShoot : MonoBehaviour
{
    public GameObject bulletObject;
    public float bulletSpeed;
    public float fireRateDuration;
    public Transform gunOffset;
    public Animator particlesAnimator;
    public AudioClip waterShot;
    public AudioSource src;
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
        src.PlayOneShot(waterShot);
        GameObject bullet = Instantiate(bulletObject, gunOffset.position, transform.rotation);
        Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.velocity = bulletSpeed * transform.up;
    }
}
