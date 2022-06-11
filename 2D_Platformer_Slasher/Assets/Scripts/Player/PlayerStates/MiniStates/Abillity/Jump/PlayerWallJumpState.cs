using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerAbilityState
{
    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    private int wallJumpDirection;

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        DetermineWallJumpDerection(player.CheckIfWall());
        player.CheckIfShouldFlip(wallJumpDirection);
        player.SetVelocity(data.wallJumpForce, data.wallJumpAngle, wallJumpDirection);
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
               
        player.Animator.SetFloat("yVelocity", player.CurrentMotion.y);

        if (Time.time >= startTime + data.wallJumpTime)
        {
            isAbilityDone = true;
        }
        
    }



    public void DetermineWallJumpDerection(bool isTouchingWall)
    {
        if (isTouchingWall)
        {
            wallJumpDirection = - player.FacingDirection;
        }
        else
        {
            wallJumpDirection = player.FacingDirection;
        }
    }

}
