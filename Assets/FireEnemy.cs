using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : MonoBehaviour
{

    public GameObject bullet;
    public float interval = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", interval, interval);
    }

    // Update is called once per frame
    void Fire()
    {
        //Spawn the bullet
        GameObject g = Instantiate(bullet, transform.position, Quaternion.identity);

        //Ignore Bullet<--> Enemy collision

        Physics2D.IgnoreCollision(g.GetComponent<Collider2D>(),
        transform.parent.GetComponent<Collider2D>());
    }
}
