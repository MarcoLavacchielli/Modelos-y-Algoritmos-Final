using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{

    private Transform player;
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float chaseRange = 5f;
    private float chaseSpeed;
    [SerializeField] private float returnSpeed = 1f;

    private Vector3 ogPosition;

    private void Start()
    {

        Enemy enemyType2Component = GetComponent<Enemy>();
        if (enemyType2Component != null)
        {
            chaseSpeed = enemyType2Component.speed;
        }
        else
        {
            Debug.LogWarning("Error al encontrar");
        }

        ogPosition = transform.position;

        GameObject playerPosition = GameObject.FindWithTag("Player");

        if (playerPosition != null)
        {
            player = playerPosition.transform;
        }
        else
        {
            Debug.Log("Falla al encontrar");
        }
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            if(distanceToPlayer < chaseRange)
            {
                Chase();
            }
            else
            {
                ReturnOGPosition();
            }
        }
        else
        {
            ReturnOGPosition();
        }
    }

    void Chase()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        transform.Translate(direction * chaseSpeed * Time.deltaTime);
    }

    private void ReturnOGPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, ogPosition, returnSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
