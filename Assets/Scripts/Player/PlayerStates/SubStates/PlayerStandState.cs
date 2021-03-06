using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerStandState : PlayerGroundedState
{

    private bool sitDownInput;

    public PlayerStandState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.wasCrouch = false;
        player.SetColliderHeight(data.standColiderHeight);
        player.InputController.UseStandUpInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        sitDownInput = player.InputController.SitDownInput;

        if (jumpInput)
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (dashImput && player.DashStandState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.DashStandState);
        }
        else if (sitDownInput)
        {           
            stateMachine.ChangeState(player.SitDownState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
