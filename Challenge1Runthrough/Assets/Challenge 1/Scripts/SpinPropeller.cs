using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *Logan Turney
 *Assignment 2
 *Spins plane propeller
 */
public class SpinPropeller : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 5f);
    }
}
