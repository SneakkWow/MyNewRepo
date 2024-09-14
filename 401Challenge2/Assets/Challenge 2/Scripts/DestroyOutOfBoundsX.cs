using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Logan Turney
* 401Challenge2
* Assignment 3
* Deletes game objects when they are off the screen
*/

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -45;
    private float bottomLimit = -6;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>().TakeDamage();
            Destroy(gameObject);
        }

    }
}
