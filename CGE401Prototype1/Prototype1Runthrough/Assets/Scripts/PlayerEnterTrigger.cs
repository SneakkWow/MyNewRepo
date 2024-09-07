using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

/*
 *Logan Turney
 *Assignment 2
 *Displays win text when passing trigger zone
 */

public class PlayerEnterTrigger : MonoBehaviour
{

    //public Text textbox;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TriggerZone"))
        {
            //textbox.text = "You Win!";
            ScoreManager.score++;
        }
    }
}
