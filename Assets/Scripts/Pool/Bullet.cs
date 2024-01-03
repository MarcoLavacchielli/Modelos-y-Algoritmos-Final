using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private int velocity;
    [SerializeField] public int damage;
    [SerializeField] private Rigidbody rb;

    private Pool<IBullet> pool;

    private Vector3 initialPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    public void Launch()
    {
        rb.velocity = transform.forward * velocity;
        StartCoroutine(ReturnAfterSeconds(3f));
    }

    void IBullet.SetActive(bool active) => gameObject.SetActive(active);

    void IBullet.SetPool(Pool<IBullet> pool) => this.pool = pool;

    void IBullet.SetPositionRotation(Vector3 position, Quaternion rotation) => transform.SetLocalPositionAndRotation(position, rotation);

    T IBullet.GetComponent<T>() => GetComponent<T>();

    private IEnumerator ReturnAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
        pool.Return(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent("PlayerController"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }

        StopCoroutine(ReturnAfterSeconds(3f));
        gameObject.SetActive(false);
        pool.Return(this);
    }
}