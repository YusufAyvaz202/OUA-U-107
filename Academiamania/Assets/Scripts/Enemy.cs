using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Hasar alma animasyonu

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        Debug.Log("Enemy dead");
        //Olme animasyonu
        // yok olma

        Destroy(gameObject);

    }
}
