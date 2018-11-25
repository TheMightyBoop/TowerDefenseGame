using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public float timeBetweenWaves = 5f;
    private float countdown = 0f;

    public GameManager gameManager;
    public EnemyMovement enemyMovement;

    [HideInInspector]
    public int waveNumber = 0;

    private void Start()
    {
        EnemiesAlive = 0;
    }

    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }

        if ((countdown <= 0f || (Input.GetKeyDown(KeyCode.E))) && waveNumber != 0)
        {
            StartCoroutine(SpawnWave());
            return;
        } else if ((Input.GetKeyDown(KeyCode.E)))
        {
            StartCoroutine(SpawnWave());
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveNumber];
        
        EnemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);

            //start countdown to next wave in middle of current wave
            if(i == wave.count / 2)
            {
                countdown = timeBetweenWaves;
            }
        }

        waveNumber++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Wave wave = waves[waveNumber];
        wave.enemyMovement.SetFirstWayPoint(wave.firstWaypointIndex);
        Instantiate(enemy, wave.spawnPoint.position, wave.spawnPoint.rotation);
    }
    
}
