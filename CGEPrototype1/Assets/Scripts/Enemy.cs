using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;

    public GameObject deathEffect;

    private DisplayBar healthBar;

    public int damage = 10;

    public void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.SetValue(health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponentInChildren<DisplayBar>();

        if (healthBar == null)
        {
            Debug.LogError("HealthBar not found");
        }

        healthBar.SetMaxValue(health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth == null)
            {
                Debug.LogError("PlayerHealth script not found");
                return;
            }

            playerHealth.TakeDamage(damage);

            playerHealth.Knockback(transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
