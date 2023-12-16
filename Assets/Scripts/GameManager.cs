using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemyFactory enemyFactoryPrefab;
    public GameObject playerCheckerPrefab;

    public void SpawnEnemy(EnemyType enemyType)
    {
        if (enemyFactoryPrefab == null)
        {
            Debug.LogError("EnemyFactoryPrefab is null in GameManager");
            return;
        }

        if (enemyFactoryPrefab == null)
        {
            enemyFactoryPrefab = Instantiate(enemyFactoryPrefab, Vector3.zero, Quaternion.identity);
        }

        if (enemyFactoryPrefab != null)
        {
            Debug.Log("Spawning enemy...");
            enemyFactoryPrefab.SpawnEnemy(enemyType, Vector3.zero);
        }
        else
        {
            Debug.LogError("EnemyFactoryInstance is null in GameManager");
        }
    }
}