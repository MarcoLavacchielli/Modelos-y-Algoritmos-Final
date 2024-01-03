using UnityEngine;

public class EnemyPatroller : MonoBehaviour
{
    [SerializeField] private LayerMask wall;
    private float speed;

    private void Start()
    {
        Enemy enemyType1Component = GetComponent<Enemy>();
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
        if (wall == (wall | (1 << collision.gameObject.layer)))
        {
            ChangeDirection();
        }
    }
}
