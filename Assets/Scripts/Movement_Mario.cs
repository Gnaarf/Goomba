﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Mario : MonoBehaviour
{
    Rigidbody2D rdbd;

    float horizontalInput;
    float speed = 3f; // 1.5f = Goomba // 3 = Mario
    bool useKeyWasPressed = false;
    void Start()
    {
        rdbd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
            useKeyWasPressed = true;
    }

    private void FixedUpdate()
    {
        if(useKeyWasPressed)
        {
            // doStuffIfMario
            rdbd.AddForce(Vector3.up * 6, ForceMode2D.Impulse);

            // doStuffIfGoomba



            useKeyWasPressed = false;
        }
        rdbd.velocity = new Vector3(horizontalInput * speed, rdbd.velocity.y, 0); 
    }
}