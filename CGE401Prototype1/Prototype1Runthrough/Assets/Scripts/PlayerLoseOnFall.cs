using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PlayerLoseOnFall : MonoBehaviour
{

    //public Text textbox;

     void Update()
    {
        if (transform.position.y < -1)
        {
            //textbox.text = "You Lose!";
            ScoreManager.gameOver = true;
        }
    }
}
