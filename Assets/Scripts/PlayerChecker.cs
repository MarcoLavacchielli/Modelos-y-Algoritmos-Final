using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
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
            Debug.Log("Player detected. Enemy type to spawn: " + enemyTypeToSpawn);
            gameManager.SpawnEnemy(enemyTypeToSpawn);
        }
    }
}