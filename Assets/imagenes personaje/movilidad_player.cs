using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movilidad_player : MonoBehaviour
{
    public float maxspeed = 3f;
    public float speed = 75f;
    public float jumpPower = 11.6f;
    public bool grounded;
    public int damage=100;
    private bool movement = true;
    private SpriteRenderer spr;

    private bool jump;
    private Animator anim;
    private Rigidbody2D rb2d;
    public Transform bulletSpawner;
    public GameObject bulletPrefab;
    private GameObject Healthbar;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Healthbar = GameObject.Find("Healthbar");


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x) );
        anim.SetBool("tocar_suelo", grounded);
       

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            jump = true;
        }
        playerShotting();
    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * h);

        float limitedspeed = Mathf.Clamp(rb2d.velocity.x, -maxspeed , maxspeed);
        rb2d.velocity = new Vector2(limitedspeed, rb2d.velocity.y);

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (jump)
        {
            anim.SetBool("salto",true);
            rb2d.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);
            jump = false;
          
        }
       
    }


    //funciones para captar la colision de el suelo
    void OnCollisionStay2D(Collision2D col)
    {
        grounded = true; 
    }
    void OnCollisionExit2D(Collision2D col)
    {
        grounded = false;
    }

    void playerShotting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("salto",false);
            anim.SetBool("isSooting", true);
            Instantiate(bulletPrefab,bulletSpawner.position,bulletSpawner.rotation);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isSooting", false);
        }

    }

    public void EnemyKnockBack(float enemyPosX)
    {
        Healthbar.SendMessage("TakeDamage", 15);

        jump = true;
        damage= damage - 15;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);

        movement = false;
        Invoke("Enablemovement",0.7f);

        Color color = new Color(255 / 255f, 106/255f , 0/255f );
        spr.color = color;        

    }



}
