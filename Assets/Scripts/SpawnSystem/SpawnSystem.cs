using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D confinerBounds;

    [Header("Spawn Settings")]
    [SerializeField] private float totalSpawnDuration = 300f;
    [SerializeField] private float minSpawnInterval = 2f;
    [SerializeField] private float maxSpawnInterval = 5f;
    [SerializeField] private int maxEnemiesAlive = 10;
    [SerializeField] private float maxRetry = 50;
    [SerializeField] private GameObject[] enemyPrefabs;

    [Space]
    [SerializeField] private float spawnTimer;
    [SerializeField] private float nextSpawnInterval;
    [SerializeField] private float elapsedTime;
    private bool isSpawning;
    [SerializeField] private List<GameObject> aliveEnemies = new();
    private void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        elapsedTime = 0f;
        isSpawning = true;
        SetNextInterval();
    }

    private void Update()
    {
        SpawningEnemy();
    }

    private void SpawningEnemy()
    {
        if (!isSpawning) return;

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= totalSpawnDuration)
        {
            isSpawning = false;
            Debug.Log("Spawn phase ended!");
            return;
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= nextSpawnInterval)
        {
            spawnTimer = 0f;
            TrySpawnEnemy();
            SetNextInterval();
        }
    }

    // Remove null entries and check if we can spawn more enemies
    private void TrySpawnEnemy()
    {
        aliveEnemies.RemoveAll(e => e == null);

        if (aliveEnemies.Count >= maxEnemiesAlive) return;

        Vector2 spawnPos = GetRandomPointInBounds();
        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        GameObject enemy = Instantiate(prefab, spawnPos, Quaternion.identity);

        aliveEnemies.Add(enemy);
    }

    private void SetNextInterval()
    {
        nextSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }


    // Get a random point within the confiner bounds that is outside the camera's view
    private Vector2 GetRandomPointInBounds()
    {
        Bounds bounds = confinerBounds.bounds;
        Camera cam = Camera.main;

        Vector2 randomPoint;
        int attempts = 0;

        do
        {
            randomPoint = new Vector2(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y)
            );
            attempts++;

            // Kiểm tra nằm trong confiner VÀ ngoài tầm nhìn camera
            Vector3 viewportPos = cam.WorldToViewportPoint(randomPoint);
            bool outsideCamera = viewportPos.x < 0 || viewportPos.x > 1 ||
                                 viewportPos.y < 0 || viewportPos.y > 1;

            if (confinerBounds.OverlapPoint(randomPoint) && outsideCamera)
                return randomPoint;

        } while (attempts < maxRetry);

        return randomPoint;
    }
}
