using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorceress : MonoBehaviour
{

    public Animator anim;
    public int maxHealth = 100;
    int currentHealth;

    EnemyAI enemyai;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        enemyai = GetComponent<EnemyAI>();
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

        enemyai.followspeed = 0;

        Destroy(gameObject, 2f);



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall"))
        {
            TakeDamage(50);
        }
    }

}
