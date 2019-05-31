using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocidad_continua : MonoBehaviour
{

    public Vector2 velocity;

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

}
