using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Logan Turney
 * 5B
 * script for keeping score after target is shot
 */

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 10)
        {
            winText.text = "You win!";
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }
}
