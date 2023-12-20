using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    [SerializeField]
    private Vector3 spawnPositionType1 = new Vector3(1f, 0f, 0f);
    [SerializeField]
    private Vector3 spawnPositionType2 = new Vector3(0f, 0f, 1f);
    [SerializeField]
    private Vector3 spawnPositionType3 = new Vector3(0f, 0f, -1f);

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
        switch (enemyType)
        {
            case EnemyType.Type1:
                return spawnPositionType1;
            case EnemyType.Type2:
                return spawnPositionType2;
            case EnemyType.Type3:
                return spawnPositionType3;
            default:
                return Vector3.zero;
        }
    }
}