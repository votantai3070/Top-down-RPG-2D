using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    [SerializeField] private Transform attackArea;
    public LayerMask enemyLayer;
    private Player player;
    private bool canHit;
    [SerializeField] Collider2D[] showTargetEnemies;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        showTargetEnemies = FindAttackTarget(attackArea);
    }

    public void Attack()
    {
        Collider2D[] targetEnemies = FindAttackTarget(attackArea);
        foreach (Collider2D enemy in targetEnemies)
        {
            if (enemy.TryGetComponent(out IDamageable damageable))
            {
                canHit = damageable.TakeDamage(player.attackDamage, transform);

                if (canHit)
                {
                    Debug.Log("Hit " + enemy.name);
                }
            }
        }
    }

    public Collider2D[] FindAttackTarget(Transform attackArea)
    {
        this.attackArea = attackArea;
        return Physics2D.OverlapCircleAll(attackArea.position, 1f, enemyLayer);
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(attackArea.position, player.attackRadius);
    //}
}
