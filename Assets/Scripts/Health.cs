using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private bool dead;

    public GameObject gameOver;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth <= 0)
        {
            if (!dead)
            {
                GetComponent<Player>().enabled = false;
                dead = true;
                gameOver.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

}
