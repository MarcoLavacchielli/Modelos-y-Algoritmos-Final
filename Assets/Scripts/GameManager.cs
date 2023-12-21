using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemyFactory enemyFactoryPrefab;
    public GameObject playerCheckerPrefab;

    private EnemyFactory enemyFactoryInstance;

    public void SpawnEnemy(EnemyType enemyType, Vector3 spawnPosition)
    {
        if (enemyFactoryPrefab == null)
        {
            Debug.LogError("EnemyFactoryPrefab is null in GameManager");
            return;
        }

        if (enemyFactoryInstance == null)
        {
            enemyFactoryInstance = Instantiate(enemyFactoryPrefab, Vector3.zero, Quaternion.identity);
        }

        if (enemyFactoryInstance != null)
        {
            Debug.Log("Spawning enemy at position: " + spawnPosition);
            enemyFactoryInstance.SpawnEnemy(enemyType, spawnPosition);
        }
        else
        {
            Debug.LogError("EnemyFactoryInstance is null in GameManager");
        }
    }
}