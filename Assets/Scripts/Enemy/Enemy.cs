using UnityEngine;

public class Enemy : Entity
{
    public Enemy_IdleState idleState { get; private set; }
    public Enemy_MoveState moveState { get; private set; }

    [SerializeField] private Transform[] patrolPoints;
    private Vector3[] patrolPointsPosition;
    private int currentPatrolIndex;

    public float idleTimer { get; set; } = 2f;

    protected override void Awake()
    {
        base.Awake();
        idleState = new(this, stateMachine, "Idle");
        moveState = new(this, stateMachine, "Move");
    }

    protected override void Start()
    {
        InitializePatrolPoints();

        stateMachine.InitializeState(idleState);
    }

    protected override void Update()
    {
        base.Update();
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
}
