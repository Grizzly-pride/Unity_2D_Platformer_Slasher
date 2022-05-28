using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchState : PlayerGroundedState
{

    private bool standUpInput;
    protected bool isRoof;

    public PlayerCrouchState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
        isRoof = player.CheckIfRoof();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetColliderHeight(data.crouchColiderHeight);
        player.wasCrouch = true;

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
            stateMachine.ChangeState(player.DashState);
        }

        if (!isRoof)
        {
            if (jumpInput)
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (standUpInput)
            {
                stateMachine.ChangeState(player.StandUpState);
            }
        }

    }

}
