using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public GameObject player;
    private Transform playerTrans;
    private Rigidbody2D bulletRB;
    public float bulletSpeed;
    public float bulletLife;

    private void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(playerTrans.localScale.x > 0)
        {
            bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y);
            transform.localScale = new Vector3(1,1,1);
        }
        else
        {
            bulletRB.velocity = new Vector2(-bulletSpeed, bulletRB.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, bulletLife);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            GetComponent<ParticleSystem>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }


}
