
using UnityEngine;

public class Enemy_ChaseState : Enemy_GroundState
{
    public Enemy_ChaseState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        float animSpeed = enemy.chaseSpeed / enemy.moveSpeed;
        anim.SetFloat("ChaseSpeed", animSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.combat.CanSeePlayer() == false)
            stateMachine.ChangeState(enemy.moveState);

        Vector2 dir = (enemy.player.position - enemy.transform.position).normalized;
        enemy.SetVelocity(dir.x * enemy.chaseSpeed, dir.y * enemy.chaseSpeed);

        if (enemy.IsPlayerInAttackRange())
            stateMachine.ChangeState(enemy.attackState);
    }
}
