using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
* Logan Turney
* 401Prototype2
* Assignment 3
* Displays the score
*/

public class DisplayScore : MonoBehaviour
{

    public Text textbox;

    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<Text>();
        //textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Score: " + score;
    }
}
