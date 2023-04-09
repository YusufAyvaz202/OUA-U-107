using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV2 : MonoBehaviour
{    
    public int maxHealth = 100; // canavarýn caný
    public int currentHealth = 100;  //canavarýn eksildikten sonraki caný

    public Animator anim; // animasyon deðiþkeni

    EnemyAIV2 enemyaiV2;
    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // anim caching
        currentHealth = maxHealth; // max healthý current healta atýyoruz

        enemyaiV2 = GetComponent<EnemyAIV2>();
        
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

        anim.SetBool("IsDead", true); // ölüm animasyonuna geçiþ

        this.enabled = false;         //tüm deðerler kapatýldý
        GetComponent<Collider2D>().enabled = false;  // collider2d kapatýldý

        enemyaiV2.followspeed = 0.0f;

        Destroy(gameObject, 2f);   //2f'lik bir zamanda yok oldu
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall"))
        {
            TakeDamage(50);
        }
    }

}
