using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 0.8f;
    public float rotatespeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += new Vector3(-1*speed, 0, 0);
            transform.Rotate(0, rotatespeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += new Vector3(speed, 0, 0);
            transform.Rotate(0, -1*rotatespeed*Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.position += new Vector3(0, 0, speed);
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += new Vector3(0, 0, -1*speed);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
