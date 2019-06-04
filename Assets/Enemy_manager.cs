using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_manager : MonoBehaviour
{

    public int enemyHealth;
    

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            enemyHealth -= BulletMovement.damage;
            

            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }

        }


    }

}
