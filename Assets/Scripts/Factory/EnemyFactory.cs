using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Type1,
    Type2,
    Type3
}

public class EnemyFactory : MonoBehaviour
{
    public GameObject enemyType1Prefab;
    public GameObject enemyType2Prefab;
    public GameObject enemyType3Prefab;

    public void SpawnEnemy(EnemyType enemyType, Vector3 spawnPosition)
    {
        GameObject enemyPrefab = GetEnemyPrefab(enemyType);

        if (enemyPrefab != null)
        {
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            if (spawnedEnemy != null)
            {
                Debug.Log("Enemy spawned: " + enemyType + " at position: " + spawnPosition);
            }
            else
            {
                Debug.LogError("Error spawning enemy: " + enemyType);
            }
        }
        else
        {
            Debug.LogError("Invalid enemy type requested");
        }
    }

    private GameObject GetEnemyPrefab(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Type1:
                return enemyType1Prefab;
            case EnemyType.Type2:
                return enemyType2Prefab;
            case EnemyType.Type3:
                return enemyType3Prefab;
            default:
                return null;
        }
    }
}