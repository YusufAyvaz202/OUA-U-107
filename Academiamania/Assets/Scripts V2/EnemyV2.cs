using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV2 : MonoBehaviour
{    
    public int maxHealth = 100; // canavar�n can�
    public int currentHealth = 100;  //canavar�n eksildikten sonraki can�

    public Animator anim; // animasyon de�i�keni

    EnemyAIV2 enemyaiV2;
    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // anim caching
        currentHealth = maxHealth; // max health� current healta at�yoruz

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

        anim.SetBool("IsDead", true); // �l�m animasyonuna ge�i�

        this.enabled = false;         //t�m de�erler kapat�ld�
        GetComponent<Collider2D>().enabled = false;  // collider2d kapat�ld�

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
