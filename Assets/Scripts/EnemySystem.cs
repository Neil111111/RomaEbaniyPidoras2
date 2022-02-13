using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    public float enemyHealth;
    public PlayerAttack _strengthAttack;

    public void TakeHit(float damage)
    {
        
        enemyHealth -= (damage * _strengthAttack.strengthAttack) + 10;

        if(enemyHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
