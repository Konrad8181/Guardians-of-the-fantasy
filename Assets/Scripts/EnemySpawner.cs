using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _spawnRange;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private List<GameObject> _enemyPrefabs = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Apply randomness to the spawn range
            float spawnRangeWithRandomness = _spawnRange * Random.Range(0.8f, 1.2f);

            // Generate a random rotation
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            // Calculate spawn position at a distance of spawnRangeWithRandomness away from the player in the direction of randomRotation
            Vector3 spawnOffset = randomRotation * Vector3.right * spawnRangeWithRandomness;
            Vector3 spawnPosition = _playerTransform.position + spawnOffset;
            spawnPosition.z = 0f; // Make sure the z-coordinate is zero for 2D

            // Randomly select an enemy prefab from the list
            GameObject enemyPrefab = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Count)];

            // Instantiate the enemy at the calculated position
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Set the player transform reference for the spawned enemy
            EnemyController enemyController = newEnemy.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.PlayerTransform = _playerTransform;
            }

            // Wait for the specified spawn delay before spawning the next enemy
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

}
