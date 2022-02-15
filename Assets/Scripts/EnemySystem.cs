using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    public float enemyHealth;
    public float speed;
    public float enemyDamage;
    

    public GameObject bloodParticles;
    public GameObject playerObject;
    /*public float stopDis;
    public float retreatDis;*/

    public Transform player;
    public PlayerAttack _strengthAttack;
    public MovementSystem _playerHealth;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() 
    {   
        
        //Shooting Enemy
        /*if(Vector2.Distance(transform.position,player.position) > stopDis)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position,player.position) < stopDis && Vector2.Distance(transform.position,player.position) > retreatDis){
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDis){
            transform.position = Vector2.MoveTowards(transform.position,player.position, -speed * Time.deltaTime);
        }*/

        //Standart enemy
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void TakeHit(float damage)
    {
        
        enemyHealth -= (damage * _strengthAttack.strengthAttack) + 10;

        if(enemyHealth <= 0)
        {
            Die();
            Instantiate(bloodParticles,transform.position,Quaternion.identity);
            
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
       if(coll.gameObject.tag == "Player")
       {
           _playerHealth.playerHealth -= 10f;
           Destroy(gameObject);
           if(_playerHealth.playerHealth <=0){
               Destroy(playerObject);
           }
       }
    }

}
