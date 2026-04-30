using UnityEngine;

public class SkillObject_Base : MonoBehaviour
{
    public StateMachine<SpellState> stateMachine { get; private set; }

    [SerializeField] protected LayerMask whatIsEnemy;
    [SerializeField] protected Transform targetCheck;
    [SerializeField] protected float checkEnemyRadius = 3;
    public float checkDamageRadius = 3;

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

    protected void DamageEnemiesInRadius(Transform t, string targetStr, int damage, Transform damageDealer)
    {
        foreach (var target in GetEnemyAround(t, checkDamageRadius))
        {
            //if (!target.CompareTag(targetStr))
            //    continue;

            IDamageable damageable = target.GetComponent<IDamageable>();

            Debug.Log("Damageable: " + damageable);

            if (damageable == null) continue;

            //AttackData attackData = playerStats.GetAttackData(damageScale);
            //ElementType element = attackData.element;

            //int physicalDamage = (int)attackData.physicalDamage;
            //int elementalDamage = (int)attackData.elementalDamage;

            targetGoHit = damageable.TakeDamage(damage, damageDealer);

            //if (element != ElementType.None)
            //target.GetComponent<Entity_StatusHandler>().ApplyStatusEffect(element, attackData.effectData);

            if (targetGoHit)
            {
                Debug.Log("Gay dmg");
                //lastTarget = target.transform;
                //target.GetComponent<Entity>().ElementalVfx(defaultDuration, element);
                //player?.playerVfx.GetImapctVfx(target.transform, attackData.isCrit);
            }

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

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(targetCheck.position, checkDamageRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(targetCheck.position, checkEnemyRadius);
    }
}
