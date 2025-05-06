using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    float speed = 0.06f;
    CarControl controller;
    // Start is called before the first frame update
    void Start()
    {
       controller = FindAnyObjectByType<CarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isgamepause == false)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed);
            if (transform.position.y <= -7.3)
            {
                Destroy(gameObject);
            }
        }    
    }
}
