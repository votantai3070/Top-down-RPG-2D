public class Player : Entity
{
    public ControlsManager controls { get; private set; }
    public float moveSpeed = 5;
    public float attackSpeed = 1;
    public float xIdleAndAttack { get; set; }
    public float yIdleAndAttack { get; set; }

    public Player_IdleState idleState { get; private set; }
    public Player_MoveState moveState { get; private set; }
    public Player_AttackState attackState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        controls = ControlsManager.instance;

        idleState = new(this, stateMachine, "Idle");
        moveState = new(this, stateMachine, "Move");
        attackState = new(this, stateMachine, "Attack");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.InitializeState(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
