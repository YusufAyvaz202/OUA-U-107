using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Transform enemyAttackPoint;
    public LayerMask enemyLayers;

    public float enemyAttackRange = 0.5f;
    public int enemyDamage = 25;

    public void DamagePlayer()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<CharacterHealth>().TakeDamage(25);

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(enemyAttackPoint.position, enemyAttackRange);
    }
}
