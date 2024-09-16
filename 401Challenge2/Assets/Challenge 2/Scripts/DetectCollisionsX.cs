using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Logan Turney
* 401Challenge2
* Assignment 3
* Detects collision between ball and dog
*/

public class DetectCollisionsX : MonoBehaviour
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
