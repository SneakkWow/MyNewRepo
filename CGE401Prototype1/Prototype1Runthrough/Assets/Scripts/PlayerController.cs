﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *Logan Turney
 *CGE401Prototype1
 *Assignment 2
 *Player movement script
 */
public class PlayerController : MonoBehaviour
{

    public float speed;

    public float forwardInput;
    public float horizontalInput;

    public float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

    }
}
