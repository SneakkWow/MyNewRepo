using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

/*
 *Logan Turney
 *Assignment 2
 *Display lose text when player goes out of bounds
 */
public class PlayerLose : MonoBehaviour
{

    //public Text textbox;

    void Update()
    {
        if (transform.position.y < -40 || transform.position.y > 70)
        {
            //textbox.text = "You Lose!";
            ScoreManager.gameOver = true;
        }
    }
}
