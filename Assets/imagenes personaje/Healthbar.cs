using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    Rigidbody2D pRB;
    public float BumpX, BumpY;

    // Start is called before the first frame update
    void Start()
    {
        pRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
          
            if (transform.localPosition.x < other.transform.localPosition.x)
            {
                pRB.velocity = new Vector2(-BumpX, BumpY);
            }
            else if (transform.localPosition.x > other.transform.localPosition.x)
            {
                pRB.velocity = new Vector2(BumpX, BumpY);
            }
        }
        
    }
}
