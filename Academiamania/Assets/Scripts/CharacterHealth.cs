using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{

    public int maxHealt = 100;
    public int currentHealth;
    public HealtBar healtBar;


    public bool enemyattack;

    public float enemytimer;

    
    void Start()
    {
        currentHealth = maxHealt;
        enemytimer = 1.5f;
    }

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

    public void TakeDamage() 
    
    {
        if (enemyattack)
        {
            currentHealth -= 20;
            enemyattack = false;

        }

        healtBar.SetHealt(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
