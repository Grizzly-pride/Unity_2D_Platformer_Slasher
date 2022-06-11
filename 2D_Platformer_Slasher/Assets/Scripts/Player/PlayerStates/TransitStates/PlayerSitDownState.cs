using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSitDownState : PlayerGroundedState
{
    public PlayerSitDownState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.InputController.UseSitDownInput();
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
                stateMachine.ChangeState(player.JumpState);
            }   
            else if (isAnimationFinished)
            {
                stateMachine.ChangeState(player.CrouchIdleState);
            }
            
        }

    }

}
