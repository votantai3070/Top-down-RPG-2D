public class Player : Entity
{
    public float moveSpeed = 5;
    public float xIdle { get; set; }
    public float yIdle { get; set; }

    public Player_IdleState idleState { get; private set; }
    public Player_MoveState moveState { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        idleState = new(this, stateMachine, "Idle");
        moveState = new(this, stateMachine, "Move");
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
