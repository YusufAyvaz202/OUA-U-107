using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingEye : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        anim.SetBool("IsDead", true);

        this.enabled = false;

        GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject, 2f);

    }
}
