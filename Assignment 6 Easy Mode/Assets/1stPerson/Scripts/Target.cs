using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Logan Turney
 * 5B
 * target script with take damage and die
 */

public class Target : MonoBehaviour
{
    public float health = 50f;

    public ScoreManager sm;

    public int value = 1;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        sm.AddScore(value);
    }
}
