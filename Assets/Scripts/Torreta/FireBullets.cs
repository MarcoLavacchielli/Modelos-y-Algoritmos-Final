using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    [SerializeField] private float _timer = 2f;
    [SerializeField] private float _range = 10f;

    [SerializeField] private int _counter;
    [SerializeField] private int _maxCounter = 20;

    private Transform _player;
    private Coroutine _fireCoroutine;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootController;
    private Pool<IBullet> bulletsPool = new Pool<IBullet>();

    //
    private void Awake()
    {
        for (int i = 0; i < 12; i++)
        {
            IBullet item = CreateBullet();
            item.SetActive(false);
            bulletsPool.Return(item);
        }
    }

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            _player = player.transform;
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.position);

        if (distance <= _range)
        {
            if (_fireCoroutine == null)
            {
                _fireCoroutine = StartCoroutine(FireBullets_CR());

            }
        }
        else
        {
            if (_fireCoroutine != null)
            {
                StopCoroutine(_fireCoroutine);
                _fireCoroutine = null;

            }
        }
    }

    IEnumerator FireBullets_CR()
    {
        Debug.Log("Inicio coroutine");
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < _maxCounter; i++)
        {
            yield return new WaitForSeconds(0.2f);

            Shoot();

            yield return new WaitForSeconds(_timer);
        }


        Debug.Log("Fin coroutine");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    private void Shoot()
    {
        IBullet newBullet = GetNextBullet();
        newBullet.SetPositionRotation(shootController.position, shootController.rotation);
        newBullet.SetActive(true);
        newBullet.Launch();
    }

    private IBullet GetNextBullet()
    {
        if (bulletsPool.TryRent(out IBullet item))
        {
            item.SetActive(true);
            return item;
        }
        return CreateBullet();
    }
    private IBullet CreateBullet()
    {
        IBullet bullet = Instantiate(bulletPrefab);
        bullet.SetPool(bulletsPool);
        return bullet;
    }
}

public interface IBullet
{
    void Launch();
    void SetPool(Pool<IBullet> pool);
    void SetActive(bool active);
    void SetPositionRotation(Vector3 position, Quaternion rotation);
    T GetComponent<T>();
}
