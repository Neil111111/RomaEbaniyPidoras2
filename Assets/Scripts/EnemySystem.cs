using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    public float enemyHealth;
    PlayerAttack _strengthAttack;
    void Awake()
    {
        _strengthAttack = GetComponent<PlayerAttack>();
    }

    public void TakeHit(float damage)
    {
        enemyHealth -= damage * _strengthAttack.strengthAttack;

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
