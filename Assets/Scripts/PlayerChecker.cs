using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    [SerializeField]
    private Vector3 spawnPosition = new Vector3(1f, 0f, 0f);

    public EnemyType enemyTypeToSpawn = EnemyType.Type1;
    public GameManager gameManager;

    public void Initialize(GameManager manager)
    {
        gameManager = manager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 spawnPosition = GetSpawnPosition(enemyTypeToSpawn);
            Debug.Log("Player detected. Enemy type to spawn: " + enemyTypeToSpawn);
            gameManager.SpawnEnemy(enemyTypeToSpawn, spawnPosition);
            Destroy(gameObject);
        }
    }

    private Vector3 GetSpawnPosition(EnemyType enemyType)
    {
        return spawnPosition;
    }
}