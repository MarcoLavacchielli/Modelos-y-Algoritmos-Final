using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    //[SerializeField] private GameObject _bullet;
    [SerializeField] private float _timer = 2f;
    [SerializeField] private float _range = 10f; // Rango de detección del jugador

    [SerializeField] private int _counter; // Esto está comentado en el for pero es un límite de balas
    [SerializeField] private int _maxCounter = 20;

    [SerializeField] private Transform _player;
    private Coroutine _fireCoroutine;

    //public ParticleSystem dustTiro;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootController;
    [SerializeField] private Rigidbody rb;
    private Pool<IBullet> bulletsPool = new Pool<IBullet>();

    //
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        for (int i = 0; i < 12; i++)   //instancia 12 balas que son las de la bolsa
        {
            IBullet item = CreateBullet();
            item.SetActive(false);
            bulletsPool.Return(item);
        }
    }
    //

    void Update()
    {
        // Calcular la distancia entre la torreta y el jugador
        float distance = Vector3.Distance(transform.position, _player.position);

        if (distance <= _range)
        {
            // El jugador está dentro del rango y no hay corutina en ejecución, iniciar la corutina
            if (_fireCoroutine == null)
            {
                _fireCoroutine = StartCoroutine(FireBullets_CR());

            }
        }
        else
        {
            // El jugador está fuera del rango, detener la corutina si está en ejecución
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
        yield return new WaitForSeconds(0.5f); // Esperar un segundo antes de disparar la primera bala

        for (int i = 0; i < _maxCounter; i++)
        {
            //dustTiro.Play();


            yield return new WaitForSeconds(0.2f); // Esperar un segundo para el cambio de material

            //Instantiate(_bullet, transform.position, transform.rotation);
            Shoot();

            yield return new WaitForSeconds(_timer);
        }


        Debug.Log("Fin coroutine");
    }

    private void OnDrawGizmosSelected()
    {
        // Dibujar una esfera gizmo para representar el rango de detección
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    private void Shoot() //Metodo de disparo, obtiene una bala del pool y la lanza desde la posicion del controller
    {
        //AudioManager.Instance.PlaySFX(0);
        IBullet newBullet = GetNextBullet();
        newBullet.SetPositionRotation(shootController.position, shootController.rotation);
        newBullet.SetActive(true);
        newBullet.Launch();
    }

    private IBullet GetNextBullet() // Obtiene la siguiente bala desde el pool
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
