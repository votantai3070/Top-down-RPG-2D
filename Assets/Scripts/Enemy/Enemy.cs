using UnityEngine;

public class Enemy : Entity
{
    public Transform player { get; private set; }
    public Enemy_Combat combat { get; private set; }
    public Enemy_Health health { get; private set; }

    public Enemy_IdleState idleState { get; private set; }
    public Enemy_MoveState moveState { get; private set; }
    public Enemy_ChaseState chaseState { get; private set; }
    public Enemy_AttackState attackState { get; private set; }
    public Enemy_DeadState deadState { get; private set; }

    [SerializeField] private Transform[] patrolPoints;
    private Vector3[] patrolPointsPosition;
    private int currentPatrolIndex;

    public float idleTimer { get; set; } = 2f;

    [Header("Detection")]
    public float detectionRadius = 5f;
    public float detectionAngle = 90f;

    [Header("Chase Info")]
    public float chaseSpeed = 8f;
    public float chaseStopDistance = 1.5f;

    [Header("Attack Info")]
    public Vector2 backOffset = new(10f, 10f);
    public float attackDistanceToPlayer = 1f;

    public Vector2 facingDirection { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        combat = GetComponent<Enemy_Combat>();
        health = GetComponent<Enemy_Health>();

        idleState = new(this, stateMachine, "Idle");
        moveState = new(this, stateMachine, "Move");
        chaseState = new(this, stateMachine, "Chase");
        attackState = new(this, stateMachine, "Attack");
        deadState = new(this, stateMachine, "Dead");
    }

    protected override void Start()
    {
        InitializePatrolPoints();

        stateMachine.InitializeState(idleState);

        facingDirection = Vector2.down;
    }

    protected override void Update()
    {
        base.Update();

        Vector2 input = new(anim.GetFloat("xMove"), anim.GetFloat("yMove"));
        if (input != Vector2.zero)
            facingDirection = input.normalized;
    }

    public void TryToIdleState()
    {
        if (stateMachine.currentState == idleState)
            return;

        stateMachine.ChangeState(idleState);
    }

    public void TryToDieState()
    {
        if (stateMachine.currentState == deadState)
            return;
        stateMachine.ChangeState(deadState);
    }

    public void SetPlayer(Transform player)
    {
        this.player = player;
    }

    public bool IsPlayerInAttackRange()
    {
        if (player == null) return false;

        float distance = Vector2.Distance(transform.position, player.position);
        return distance <= attackDistanceToPlayer;
    }

    public Vector3 GetPatrolDestination()
    {
        Vector3 destination = patrolPointsPosition[currentPatrolIndex];

        currentPatrolIndex++;

        if (currentPatrolIndex >= patrolPoints.Length)
            currentPatrolIndex = 0;

        return destination;
    }

    private void InitializePatrolPoints()
    {
        patrolPointsPosition = new Vector3[patrolPoints.Length];

        for (int i = 0; i < patrolPoints.Length; i++)
        {
            patrolPointsPosition[i] = patrolPoints[i].position;
            patrolPoints[i].gameObject.SetActive(false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.red;
        Vector3 leftDir = Quaternion.Euler(0, 0, detectionAngle / 2f) * facingDirection;
        Vector3 rightDir = Quaternion.Euler(0, 0, -detectionAngle / 2f) * facingDirection;
        Gizmos.DrawRay(transform.position, leftDir * detectionRadius);
        Gizmos.DrawRay(transform.position, rightDir * detectionRadius);
    }
}
