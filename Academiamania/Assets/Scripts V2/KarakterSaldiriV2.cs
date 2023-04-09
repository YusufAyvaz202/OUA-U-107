using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterSaldiriV2 : MonoBehaviour
{

    public Transform attackPoint;
    public Transform attackPoint2;

    public LayerMask enemyLayers;




    public float attackRange = 0.5f;
    public int damage = 25;

    public void DamageEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Zarar" + enemy.name);

            enemy.GetComponent<goblin>().TakeDamage(damage);
        }
        Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Zarar" + enemy.name);

            enemy.GetComponent<goblin>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange);

    }




}
