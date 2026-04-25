public class Enemy_IdleState : Enemy_GroundState
{
    public Enemy_IdleState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTimer;

        enemy.SetVelocity(0f, 0f);

        anim.SetFloat("xIdleAndAttack", enemy.xIdleAndAttack);
        anim.SetFloat("yIdleAndAttack", enemy.yIdleAndAttack);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.moveState);
    }
}
