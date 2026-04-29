using UnityEngine;

public class SkillObject_Base : MonoBehaviour
{
    public StateMachine<SpellState> stateMachine { get; private set; }

    [SerializeField] protected LayerMask whatIsEnemy;
    [SerializeField] protected Transform targetCheck;
    [SerializeField] protected float checkDamageRadius = 1;
    [SerializeField] protected float checkEnemyRadius = 3;
    //[SerializeField] private float defaultDuration = 2f;

    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    protected Entity entity;
    protected Player player;
    //protected Entity_Stats playerStats;
    //protected DamageScaleData damageScale;
    //protected ElementType currentElement;
    protected Transform lastTarget;
    protected bool targetGoHit;

    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine = new();

        rb.gravityScale = 0;
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        stateMachine.currentState.Update();
    }

    protected void DamageEnemiesInRadius(Transform t, float radius)
    {
        foreach (var target in GetEnemyAround(t, radius))
        {
            if (!target.CompareTag("Enemy"))
                continue;

            IDamageable damageable = target.GetComponent<IDamageable>();

            if (damageable == null) continue;

            //AttackData attackData = playerStats.GetAttackData(damageScale);
            //ElementType element = attackData.element;

            //int physicalDamage = (int)attackData.physicalDamage;
            //int elementalDamage = (int)attackData.elementalDamage;

            //targetGoHit = damageable.TakeDamage(physicalDamage, elementalDamage, element, transform);

            //if (element != ElementType.None)
            //    target.GetComponent<Entity_StatusHandler>().ApplyStatusEffect(element, attackData.effectData);

            //if (targetGoHit)
            //{
            //    lastTarget = target.transform;
            //    target.GetComponent<Entity>().ElementalVfx(defaultDuration, element);
            //    player?.playerVfx.GetImapctVfx(target.transform, attackData.isCrit);
            //}

            //currentElement = element;
        }
    }

    protected Collider2D[] GetEnemyAround(Transform t, float radius)
    {
        return Physics2D.OverlapCircleAll(t.position, radius, whatIsEnemy);
    }

    protected virtual void OnDrawGizmos()
    {
        if (targetCheck == null)
            targetCheck = transform;

        Gizmos.DrawWireSphere(targetCheck.position, checkDamageRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(targetCheck.position, checkEnemyRadius);
    }
}
