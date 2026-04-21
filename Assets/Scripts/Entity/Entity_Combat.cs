using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    [SerializeField] private Transform attackArea;
    public LayerMask enemyLayer;
    private Player player;
    [SerializeField] Collider2D[] showTargetEnemies;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        showTargetEnemies = FindAttackTarget(attackArea);
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
