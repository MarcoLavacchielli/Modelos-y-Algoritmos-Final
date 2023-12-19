using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRadius = 1.5f;
    [SerializeField] private LayerMask enemyLayer;
    public int danio;

    [SerializeField] private GameObserver gameObserver;

    [SerializeField] private ParticleSystem attackPs;

    [SerializeField] private float cooldown = 0.5f;
    private float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + cooldown;
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRadius, enemyLayer);
        attackPs.Play();

        foreach (Collider enemy in hitEnemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(danio);
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
        gameObserver.DamageChanged += HandleDamageChanged;
    }

    private void OnDisable()
    {
        gameObserver.DamageChanged -= HandleDamageChanged;
    }

    private void HandleDamageChanged(int amount)
    {
        danio += amount;
    }
}