using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public float damage;
   
   private void OnCollisionEnter2D(Collision2D coll)
   {
       if(coll.gameObject.tag == "Enemy")
       {
           EnemySystem health = coll.gameObject.GetComponent<EnemySystem>();
           health.TakeHit(damage);
       }
   }
}
