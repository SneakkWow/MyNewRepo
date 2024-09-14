using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Logan Turney
* 401Prototype2
* Assignment 3
* Destroys game objects when they go too far out of bounds
*/
public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 45;
    public float bottomBound = -10;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < bottomBound)
        {
            GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>().TakeDamage();

            Destroy(gameObject);
        }
    }
}
