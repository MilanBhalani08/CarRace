using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Road : MonoBehaviour
{
    Renderer rr;
    float Yset = 0;
    CarControl controller;

    // Start is called before the first frame update
    void Start()
    {
        rr=GetComponent<Renderer>();
        controller = FindAnyObjectByType<CarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isgamepause == false)
        {
            Yset = Time.time * 0.4f;
            rr.material.SetTextureOffset("_MainTex", new Vector2(0, Yset));
        }
      
    }
}
