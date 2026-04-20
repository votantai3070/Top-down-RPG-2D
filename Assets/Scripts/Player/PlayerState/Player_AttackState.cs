public class Player_AttackState : PlayerState
{
    public Player_AttackState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();


        anim.SetFloat("AttackSpeed", player.attackSpeed);
        anim.SetFloat("xIdleAndAttack", player.xIdleAndAttack);
        anim.SetFloat("yIdleAndAttack", player.yIdleAndAttack);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(0, 0);

        if (player.canTriggerAttack)
        {
            player.canTriggerAttack = false;
            stateMachine.ChangeState(player.idleState);
        }
    }
}
