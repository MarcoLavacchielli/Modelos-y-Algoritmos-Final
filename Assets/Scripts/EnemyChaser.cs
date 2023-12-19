using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private float chaseSpeed = 3f;
    [SerializeField] private float returnSpeed = 1f;

    private Vector3 ogPosition;

    private void Start()
    {
        ogPosition = transform.position;
    }

    private void Update()
    {
        // calculo distancia
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        //distance se usa en caso de que tenga varios guardias asi no se rompen y van todos al pobre player
        if (distanceToPlayer <= detectionRange)
        {
            if(distanceToPlayer < chaseRange)
            {
                Chase();
            }
            else
            {
                returnOGPosition();
            }
        }
        else
        {
            returnOGPosition();
        }
    }

    void Chase()
    {
        //distancia hacia el player
        Vector3 direction = (player.position - transform.position).normalized;

        transform.Translate(direction * chaseSpeed * Time.deltaTime);
    }

    void returnOGPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, ogPosition, returnSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        // Dibujar una esfera gizmo para representar el rango de chase
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
