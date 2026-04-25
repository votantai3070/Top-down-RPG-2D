using UnityEngine;

public class Enemy_MoveState : Enemy_GroundState
{
    private Vector2 direction;
    private float arriveDistance = 0.3f;
    private Vector3 destination;

    public Enemy_MoveState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        destination = enemy.GetPatrolDestination();

        GetDirection();
    }

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(direction.x * enemy.moveSpeed, direction.y * enemy.moveSpeed);

        anim.SetFloat("xMove", Mathf.Round(direction.x));
        anim.SetFloat("yMove", Mathf.Round(direction.y));

        if (Vector2.Distance(enemy.transform.position, destination) <= arriveDistance)
            stateMachine.ChangeState(enemy.idleState);

    }

    public override void Exit()
    {
        base.Exit();
    }

    private void GetDirection()
    {
        direction = (destination - enemy.transform.position).normalized;
    }
}