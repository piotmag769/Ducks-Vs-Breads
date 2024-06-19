using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float maximumHealth;

    public AudioSource src;
    public AudioClip quack;
    public AudioClip gameOver;

    public bool IsInvincible { get; set; }

    public UnityEvent OnDeath;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;

    public float RemainingHealthPercentage
    {
        get { return currentHealth / maximumHealth; }
    }

    public void TakeDamage(float damageAmount)
    {
        if (currentHealth == 0 || IsInvincible) { return; }

        currentHealth = Mathf.Max(currentHealth - damageAmount, 0);
        OnHealthChanged.Invoke();

        if (currentHealth == 0) {
            src.clip = gameOver;
            src.Play();
            OnDeath.Invoke();
            SceneManager.LoadSceneAsync(7);
        }
        else {
            src.clip = quack;
            src.Play();
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float toAdd)
    {
        currentHealth = Mathf.Min(currentHealth + toAdd, maximumHealth);
    }
}
