using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Logan Turney
* 401Challenge2
* Assignment 3
* Spawns dogs
*/
public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    public bool dogSpawned = false;

    public HealthSystem healthSystem;

    public bool gameOver = false;
    void Start()
    {
        StartCoroutine(SpawnNewDog());

        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && !dogSpawned)
        {
            dogSpawned = true;
            SpawnNewDog();
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
        
    }

    IEnumerator SpawnNewDog()
    {

        while (!healthSystem.gameOver)
        {
            yield return new WaitForSeconds(1f);

            dogSpawned = false;
        }
        
    }
}
