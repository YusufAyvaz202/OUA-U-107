using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCombat : MonoBehaviour
{

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int attackDamage = 20;//Silaha göre deðiþecek.
    public float attackRange = 0.5f;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Saldýrý animasyonu


        // düþman menzilde mi
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);



        // Hasar ver

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }



    }

    private void OnDrawGizmosSelected()//Kýlýç menzili görmek için oyun dýþý küre silinecek.
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
