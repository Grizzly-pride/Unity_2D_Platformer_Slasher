using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchState : PlayerGroundedState
{

    private bool standUpInput;

    public PlayerCrouchState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        player.SetColliderHeight(data.crouchColiderHeight);
        player.wasCrouch = true;
        player.InputController.UseStandUpInput();
    }

    public override void Exit()
    {
        base.Exit();
        player.SetColliderHeight(data.standColiderHeight);
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        standUpInput = player.InputController.StandUpInput;

        if (dashImput && player.DashState.CheckIfCanDash())
        {
            player.InputController.UseDashInput();
            stateMachine.ChangeState(player.DashState);
        }

        if (!isRoof)
        {
            if (jumpInput)
            {
                player.InputController.UseJumpInput();
                stateMachine.ChangeState(player.JumpState);
            }
            else if (standUpInput)
            {
                player.InputController.UseStandUpInput();
                stateMachine.ChangeState(player.StandUpState);
            }
        }

    }

}
