using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroller : MonoBehaviour
{
    //[SerializeField] private float speed = 5f;
    private float speed;

    private void Start()
    {
        EnemyType1 enemyType1Component = GetComponent<EnemyType1>();
        if (enemyType1Component != null)
        {
            speed = enemyType1Component.speed;
        }
        else
        {
            Debug.LogWarning("Error al encontrar");
        }

        transform.Rotate(0f, 90f, 0f);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //si se pega con una "wall" cambia de direccion en 180
        if (collision.gameObject.CompareTag("Wall"))
        {
            ChangeDirection();
        }
    }
}
