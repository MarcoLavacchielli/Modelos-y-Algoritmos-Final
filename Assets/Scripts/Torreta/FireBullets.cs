using System.Collections;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    [SerializeField] private float timer = 2f;
    [SerializeField] private float range = 10f;

    [SerializeField] private int counter;
    [SerializeField] private int maxCounter = 20;

    private Coroutine fireCoroutine;
    private PlayerController playerController;

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
        playerController = FindObjectOfType<PlayerController>();

        if (playerController == null)
        {
            Debug.LogError("Falla al encontrar el PlayerController");
        }
    }

    void Update()
    {
        if (playerController != null)
        {
            float distance = Vector3.Distance(transform.position, playerController.transform.position);

            if (distance <= range)
            {
                if (fireCoroutine == null)
                {
                    fireCoroutine = StartCoroutine(FireBullets_CR());
                }
            }
            else
            {
                if (fireCoroutine != null)
                {
                    StopCoroutine(fireCoroutine);
                    fireCoroutine = null;
                }
            }
        }
    }

    IEnumerator FireBullets_CR()
    {
        Debug.Log("Inicio coroutine");
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < maxCounter; i++)
        {
            yield return new WaitForSeconds(0.2f);

            Shoot();

            yield return new WaitForSeconds(timer);
        }


        Debug.Log("Fin coroutine");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
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
