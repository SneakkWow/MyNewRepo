using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Logan Turney
* 401Prototype2
* Assignment 3
* Detects collisions between the food and animals
*/

public class DetectCollisions : MonoBehaviour
{

    private DisplayScore displayScoreScript;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }
    private void OnTriggerEnter(Collider other)
    {
        displayScoreScript.score++;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
