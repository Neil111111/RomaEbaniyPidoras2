using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //variables
    public float strengthAttack;
    public float maxStrengthAttack;
    public bool isCharging = true;
    public MovementSystem _movementSystem;
    MovementSystem movespeed;
    Rigidbody2D rb;
    

    
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
        if(isCharging == false){
            Impulse();
            movespeed._moveSpeed = 7f;  
            isCharging = true;
        }
    }
    
    
    void Impulse()
    {
        rb.AddForce(transform.right * strengthAttack * 300f); 
        //rb.AddForce(new Vector2(movespeed.lookDir * strengthAttack,0));
        strengthAttack = 0f;
    }

    void myInputs()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            isCharging = false;
        }
    }

    
   
}
