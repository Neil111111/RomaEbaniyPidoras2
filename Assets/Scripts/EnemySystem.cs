using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class EnemySystem : MonoBehaviour
{
    public float enemyHealth;
    public float speed;
    public float enemyDamage;
    

    public GameObject bloodParticles;
    public GameObject playerObject;
    public GameObject isDead;

    /*public float stopDis;
    public float retreatDis;*/

    public Transform player;
    //public PlayerAttack _strengthAttack;
    public MovementSystem _playerHealth;
    EnemySystem _enemySystem;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isDead.SetActive(false);
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
        
        if(_playerHealth.playerHealth <= 0 ){
            playerObject.SetActive(false);
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            _enemySystem.enabled = false;
            isDead.SetActive(true);
            
        }
    }

    public void TakeHit(float damage)
    {
        
        enemyHealth -= 100;

        if(enemyHealth <= 0){
        
            Die();   
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Instantiate(bloodParticles,transform.position,Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
       if(coll.gameObject.tag == "Player")
       {
           _playerHealth.playerHealth -= 10f;  
           Die();
       }
    }

}
