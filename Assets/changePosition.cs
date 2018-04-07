using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePosition : MonoBehaviour
{
    bool buttonpressedRight = false;
    bool buttonpressedLeft = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.RightArrow) && !buttonpressedRight)
        {
            transform.Translate(0, -1, 0);
            buttonpressedLeft = false;
            buttonpressedRight = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !buttonpressedLeft)
        {
            transform.Translate(0, 1, 0);
            buttonpressedLeft = true;
            buttonpressedRight = false;
        }
    }
}