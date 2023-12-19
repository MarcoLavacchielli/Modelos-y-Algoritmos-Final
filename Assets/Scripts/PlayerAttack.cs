using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRadius = 1.5f;
    [SerializeField] private LayerMask enemyLayer;
    public int danio;

    [SerializeField] private GameObserver gameObserver;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Debug.Log("ataca");
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRadius, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            //Debug.Log("ataca enemigos");
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(danio);
                //Debug.Log("da�o hecho");
            }
            else
            {
                //Debug.Log("no hizo da�o");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    private void OnEnable()
    {
        // Suscribe al evento cuando el objeto est� activo
        gameObserver.DamageChanged += HandleDamageChanged;
    }

    private void OnDisable()
    {
        // Desuscribe al evento cuando el objeto se desactiva para evitar p�rdida de referencia
        gameObserver.DamageChanged -= HandleDamageChanged;
    }

    private void HandleDamageChanged(int amount)
    {
        // Actualiza el da�o seg�n el evento recibido
        danio += amount;
    }
}