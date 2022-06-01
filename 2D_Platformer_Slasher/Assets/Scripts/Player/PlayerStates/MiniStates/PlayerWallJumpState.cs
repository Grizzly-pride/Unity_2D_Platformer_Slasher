using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    private int xInput;

    private int wallJumpDirection;

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(data.wallJumpForce, data.wallJumpAngle, -1);  
    }

    public override void Exit()
    {
        base.Exit();
        player.wasWall = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + data.wallJumpTime)
        {
            stateMachine.ChangeState(player.InAirState);
        }

    }

    public void DetermineWallJumpDerection(bool isTouchingWall)
    {
        if (isTouchingWall)
        {
            wallJumpDirection = player.FacingDirection;
        }
        else
        {
            wallJumpDirection = - player.FacingDirection;
        }
    }
}
