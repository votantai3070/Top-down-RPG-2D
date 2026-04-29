using UnityEngine;

public class Enemy_DeadState : EnemyState
{
    public Enemy_DeadState(Enemy enemy, StateMachine<EntityState> stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = anim.GetCurrentAnimatorStateInfo(0).length;

        enemy.SetVelocity(0, 0);
        enemy.rb.simulated = false;
        enemy.GetComponent<Collider2D>().enabled = false;
    }

    public override void Exit()
    {
        base.Exit();

        enemy.rb.simulated = true;
        enemy.GetComponent<Collider2D>().enabled = true;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer <= 0f)
        {
            stateMachine.ChangeState(enemy.idleState);
            enemy.health.Die();
        }
    }

}
