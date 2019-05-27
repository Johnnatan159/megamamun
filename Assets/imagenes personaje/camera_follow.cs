using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject follow;
    public Vector2 minCamPos, MaxCamPos;    


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = follow.transform.position.x;
        

        transform.position = new Vector3( Mathf.Clamp(posX,minCamPos.x,MaxCamPos.x), 0,transform.position.z);
    }
}
