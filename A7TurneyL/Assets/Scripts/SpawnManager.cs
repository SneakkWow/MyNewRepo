using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int enemyCount;

    public int waveNumber = 1;

    public GameObject powerupPrefab;

    public Text score;
    public Text win;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerUps(1);
        //Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            score.text = "Wave: " + waveNumber.ToString();
            SpawnEnemyWave(waveNumber);
            SpawnPowerUps(1);

            if (waveNumber > 10)
            {
                score.gameObject.SetActive(false);
                win.gameObject.SetActive(true);
                Time.timeScale = 0f;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; ++i)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerUps(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; ++i)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
