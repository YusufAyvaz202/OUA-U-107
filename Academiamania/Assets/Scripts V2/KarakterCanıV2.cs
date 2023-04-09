using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterCanıV2 : MonoBehaviour
{
    //karakterin canı ile alakalı
    public int maxHealth = 100;
    public int currentHealth;
    public KarakterCanBarıV2 CanBarı;

    //düşmanın belirli aralıkta saldırması için değikenler
    public bool enemyattack;

    public float enemytimer;

    public Animator anim;

    
    void Start()
    {
        currentHealth = maxHealth;
        enemytimer = 1.5f;

        anim = GetComponent<Animator>();
    }

    void EnemyAttackSpacing()   //düşmanın bize zarar verme aralığı
    {
        if (enemyattack == false) 
        {
            enemytimer -= Time.deltaTime;
        }

        if (enemytimer < 0)        
        {
            enemytimer = 0f;
        }
        if (enemytimer == 0)
        {
            enemyattack = true;
            enemytimer = 1.5f;
        }
    }

    void CharacterDamage()                             // Karakterimiz saldrdığında düşman biraz geç saldırsın veya kitlensin.
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            enemyattack = false;
        }

    }

    public void TakeDamage(int damage)                        // karakterimizin zarar görmesi.
    {
        if (enemyattack)
        {
            currentHealth -= 20;
            enemyattack = false;
            anim.SetTrigger("isHurt");
        }

        CanBarı.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }
        

    
    void Update()
    {
        EnemyAttackSpacing();
        CharacterDamage();

    }

    void Die()
    {
        anim.SetBool("isDead", true);

        GetComponent<KarakterKontrolV2>().enabled = false;

        Destroy(gameObject, 2f);
    }
}
