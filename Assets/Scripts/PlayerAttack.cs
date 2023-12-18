using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRadius = 1.5f;
    [SerializeField] private LayerMask enemyLayer;
    public int danio;

    private void Awake()
    {
        danio = 1;
    }

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
                //Debug.Log("daño hecho");
            }
            else
            {
                //Debug.Log("no hizo daño");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}