using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType3Factory : MonoBehaviour, IEnemyFactory
{
    public GameObject enemyPrefab;

    public GameObject SpawnEnemy(Vector3 spawnPosition)
    {
        return Object.Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
