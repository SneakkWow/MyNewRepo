using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    //public GameObject SM;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.FindGameObjectWithTag("PlayerGoal");
        //SM = GameObject.FindGameObjectWithTag("SM");
        //score = GameObject.FindGameObjectWithTag("waveText");
        //lose = GameObject.FindGameObjectWithTag("loseText");
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            //SM.Lose();
            Destroy(gameObject);
        }

    }

}
