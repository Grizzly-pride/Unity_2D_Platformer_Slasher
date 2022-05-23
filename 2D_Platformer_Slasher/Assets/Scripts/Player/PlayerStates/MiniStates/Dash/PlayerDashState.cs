using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerGroundedState
{
    private float lastDashTime;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetPhysicsMaterial(data.noFrictionMaterial);
        player.SetColliderHeight(data.crouchColiderHeight);
        startTime = Time.time;
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {

            if (!player.wasCrouch)
            {
                if (Time.time <= startTime + data.dashTime)
                {
                    player.MovementOnGround(isSlope, data.dashSpeed, player.FacingDirection);
                }
                else
                {                   
                    lastDashTime = Time.time;

                    if (isRoof)
                    {
                        stateMachine.ChangeState(player.DashToCrouchState);
                    }
                    else
                    {
                        stateMachine.ChangeState(player.DashToStandState);
                    }
                }
            }           
            else
            {
                if (Time.time <= startTime + data.dashTime)
                {
                    player.MovementOnGround(isSlope, data.dashSpeed, player.FacingDirection);
                }
                else
                {
                    lastDashTime = Time.time; 
                    stateMachine.ChangeState(player.DashToCrouchState);
                }

            }
        }
    }

    
    public bool CheckIfCanDash()
    {

        return  Time.time >= lastDashTime + data.dashCoolDown;
    }


}
