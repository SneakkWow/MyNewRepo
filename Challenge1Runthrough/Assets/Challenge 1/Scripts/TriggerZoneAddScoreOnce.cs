using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *Logan Turney
 *Challenge1Runthrough
 *Assignment 2
 *Adds score when passing a trigger zone
 */

public class TriggerZoneAddScoreOnce : MonoBehaviour
{

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            ScoreManager.score++;
        }
    }
}
