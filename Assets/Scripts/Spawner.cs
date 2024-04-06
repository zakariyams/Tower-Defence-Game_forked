using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private GameObject[] enemyprefabs;



    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 2f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    [Header("Test")]
    [SerializeField] private int currentWave = 1;
    [SerializeField] private float timeSinceLastSpawn;
    [SerializeField] private int enemiesAlive;
    [SerializeField] private int enemiesLeftToSpawn;
    [SerializeField] private bool isSpawning = false;

    [Header("Events")]
    public static UnityEvent onEnemyDestroyed = new UnityEvent();

    private void Awake()
    {
        onEnemyDestroyed.AddListener(EnemyDestroyed);
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
    private void Start()
    {
        StartCoroutine(StartWave());
    }
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }
    private void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if(enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }
    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyprefabs[0];
        Instantiate(prefabToSpawn, LevelManager.main.StartPoint.position, Quaternion.identity);
    }



    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}




