using UnityEngine;

public class Player_GroundState : PlayerState
{
    public Player_GroundState(Player player, StateMachine<EntityState> stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        // Transition to Attack State
        if (controls.PressedAttack())
        {
            stateMachine.ChangeState(player.attackState);
        }

        // Transition to Move State
        if (player.isSprinting == false && controls.moveInput != Vector2.zero)
        {
            stateMachine.ChangeState(player.moveState);
        }

        #region Dash & Sprint
        // Press Shift
        if (controls.inputActions.Player.Sprint.WasPressedThisFrame())
        {
            if (player.hasDashed == false)
            {
                stateMachine.ChangeState(player.dashState);
            }

            player.isHolding = true;
            player.holdTimer = 0f;
        }

        // Hold Shift
        if (player.isHolding)
        {
            player.holdTimer += Time.deltaTime;

            if (player.holdTimer >= player.holdThreshold && player.hasDashed)
            {
                player.isSprinting = true;
                player.hasDashed = true;
                stateMachine.ChangeState(player.sprintState);
            }
        }

        // Release Shift
        if (controls.inputActions.Player.Sprint.WasReleasedThisFrame())
        {
            player.hasDashed = false;
            player.isSprinting = false;
            player.isHolding = false;
            player.holdTimer = 0f;
        }
        #endregion
    }
}
