using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //variables
    public float strengthAttack;
    public float maxStrengthAttack;
    public bool isCharging = true;
    MovementSystem movespeed;
    Rigidbody2D rb;
    /*public float damage = 0.0f;
    public float maxDamage = 100.0f;
    public float speed = 2.0f;
    public float t = 0.0f;*/

    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
        movespeed = GetComponent<MovementSystem>();
    }

    void Update()
    {
        myInputs();

        if(Input.GetButton("Fire1") && strengthAttack < maxStrengthAttack && movespeed._moveSpeed > 1)
        {
            isCharging = true;
            strengthAttack += 3.5f * Time.deltaTime;
            movespeed._moveSpeed -= Time.deltaTime;
        }     
    }
    void FixedUpdate()
    {
        /*if (Input.GetMouseButton(0))
        {
            t += Time.deltaTime * speed;

            damage = Mathf.PingPong(t, maxDamage);
        }

       if (Input.GetMouseButtonUp(0))
        {
            t = 0.0f;

            print($"piu piu {damage}");
        }
        */

        
        
        if(isCharging == false){
            Impulse();
            strengthAttack = 0f;
            movespeed._moveSpeed = 7f;  
            isCharging = true;
        }
    }
    
    
     void Impulse()
    {
        rb.AddForce(transform.right * strengthAttack * 300f);
    }

    void myInputs()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            isCharging = false;
        }
    }
    
   
}
