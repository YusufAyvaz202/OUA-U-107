using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    // sa�l�k ile ilgili kodlar
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healtBar;



    // d��man�n belirli aral�kta sald�rmas�n� sa�lar
    public bool enemyattack;

    public float enemytimer;

    
    void Start()
    {
        currentHealth = maxHealth;
        enemytimer = 1.5f;
    }
    // d��man�n bize zarar verme aral���
    void EnemyAttackSpacing() 
    {
        if (enemyattack == false) 
        {
            enemytimer -= Time.deltaTime;
        }

        if (enemytimer < 0)
        {
            enemytimer = 0f;
        }

        if (enemytimer == 0f)
        {
            enemyattack = true;
            enemytimer = 1.5f;
        }

    }


    // D��man hasar ald���nda vuramas�n bize
    void CharacterDamage() 
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            enemyattack = false;
        }
    
    }


    //karakterimizin hasar almas�
    public void TakeDamage(int damage) 
    
    {
        if (enemyattack)
        {
            currentHealth -= 20;
            enemyattack = false;

        }

        healtBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {

        CharacterDamage();
        EnemyAttackSpacing();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(20);
        }

    }
}
