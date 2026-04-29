public class Player_DashState : Player_GroundState
{
    public Player_DashState(Player player, StateMachine<EntityState> stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(player.dashSpeed * controls.moveInput.x, player.dashSpeed * controls.moveInput.y);

    }

    public override void Exit()
    {
        base.Exit();

        player.hasDashed = true;
    }

    public override void Update()
    {
        base.Update();
    }
}
