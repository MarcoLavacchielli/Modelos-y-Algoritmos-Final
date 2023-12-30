using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRadius = 1.5f;
    [SerializeField] private LayerMask enemyLayer;
    public int danio;
    private bool isAttacking = false;

    [SerializeField] private GameObserver gameObserver;

    [SerializeField] private ParticleSystem attackPs;

    [SerializeField] private Charview view;

    [SerializeField] private float cooldown = 0.5f;
    private float nextAttackTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextAttackTime && !isAttacking)
        {
            isAttacking = true;
            StartCoroutine(PerformAttack());
            nextAttackTime = Time.time + cooldown;
        }
    }

    IEnumerator PerformAttack()
    {
        view.Iskicking(true);

        yield return new WaitForSeconds(0.5f);

        Attack();

        yield return new WaitForSeconds(0.5f);

        view.Iskicking(false);

        isAttacking = false;
    }

    private void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRadius, enemyLayer);
        attackPs.Play();
        AudioManager.Instance.PlaySFX(1);

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