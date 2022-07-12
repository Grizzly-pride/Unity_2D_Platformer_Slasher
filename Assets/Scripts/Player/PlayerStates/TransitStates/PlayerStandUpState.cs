using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStandUpState : PlayerGroundedState
{
    public PlayerStandUpState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.InputController.UseStandUpInput();
        player.SetPhysicsMaterial(data.frictionMaterial);
        player.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (jumpInput)
            {
                player.InputController.UseJumpInput();
                stateMachine.ChangeState(player.JumpState);
            }
            else if (isAnimationFinished)
            {
                stateMachine.ChangeState(player.StandIdleState);
            }

        }    
    }

}
