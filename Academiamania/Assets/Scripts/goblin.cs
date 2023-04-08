using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{

    public Animator anim;
    public int maxHealth = 100;
    int currentHealt;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        currentHealt = maxHealth;
    }

    public void TakeDamage(int damage) 
    {
        currentHealt -= damage;

        anim.SetTrigger("Hurt");

        if (currentHealt <= 0)
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
