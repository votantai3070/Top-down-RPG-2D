using UnityEngine;

public class Player_MoveState : PlayerState
{
    public Player_MoveState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        float moveInputX = controls.moveInput.x;
        float moveInputY = controls.moveInput.y;

        anim.SetFloat("xMove", moveInputX);
        anim.SetFloat("yMove", moveInputY);

        if (controls.moveInput != Vector2.zero)
        {
            player.xIdle = moveInputX;
            player.yIdle = moveInputY;
        }

        player.SetVelocity(moveInputX * player.moveSpeed, moveInputY * player.moveSpeed);

        if (controls.moveInput == Vector2.zero)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }
}
