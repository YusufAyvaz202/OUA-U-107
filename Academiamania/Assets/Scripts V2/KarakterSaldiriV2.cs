using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterSaldiriV2 : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 25;

    public void DamageEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyV2>().TakeDamage(attackDamage); //kendi karakterimiz attack'da bulundu�unda bunu damage olarak enemyde g�rmemiz i�in.
           // Debug.Log("Zarar" + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }




}
