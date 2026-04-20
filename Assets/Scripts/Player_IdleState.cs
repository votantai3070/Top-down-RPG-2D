using UnityEngine;

public class Player_IdleState : PlayerState
{
    public Player_IdleState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        anim.SetFloat("xIdle", player.xIdle);
        anim.SetFloat("yIdle", player.yIdle);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (controls.moveInput != Vector2.zero)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
