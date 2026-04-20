public class Player_IdleState : Player_GroundState
{
    public Player_IdleState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        anim.SetFloat("xIdleAndAttack", player.xIdleAndAttack);
        anim.SetFloat("yIdleAndAttack", player.yIdleAndAttack);
    }

    public override void Update()
    {
        base.Update();

        if (controls.moveInput.magnitude > 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
