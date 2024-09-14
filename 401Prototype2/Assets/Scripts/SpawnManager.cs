using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Logan Turney
* 401Prototype2
* Assignment 3
* Spawns the animals at the top of the screen in random intervals and random placements
*/

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;

    public HealthSystem healthSystem;

    private float leftBound = -15;
    private float rightBound = 15;
    private float spawnPosZ = 40;

    public bool gameOver = false;

    void Start()
    {
        //InvokeRepeating("SpawnRandomPrefab", 2, 1.5f);

        StartCoroutine(SpawnRandomPrefabWithCoroutine());

        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }

    IEnumerator SpawnRandomPrefabWithCoroutine()
    {
        yield return new WaitForSeconds(3f);

        while (!healthSystem.gameOver)
        {
            SpawnRandomPrefab();

            float randomDelay = Random.Range(1.5f, 3.0f);

            yield return new WaitForSeconds(randomDelay);
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomPrefab();
        }

    }*/

    void SpawnRandomPrefab()
    {
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }
}
