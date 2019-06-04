using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Game : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemigoUltimo")
        {
            Debug.Log("Se ha acabado el juego");
        }
    }

}
