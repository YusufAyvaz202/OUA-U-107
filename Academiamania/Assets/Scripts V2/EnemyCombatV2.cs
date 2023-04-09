using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatV2 : MonoBehaviour
{
    public Transform enemyAttackPoint;
    public LayerMask playerLayers;

    public float enemyAttackRange = 0.5f;
    public int enemyAttackDamage = 25;

    public void DamagePlayer()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<KarakterCanýV2>().TakeDamage(enemyAttackDamage); //kendi karakterimiz attack'da bulunduðunda bunu damage olarak enemyde görmemiz için.
            // Debug.Log("Zarar" + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(enemyAttackPoint.position, enemyAttackDamage);

    }
}
