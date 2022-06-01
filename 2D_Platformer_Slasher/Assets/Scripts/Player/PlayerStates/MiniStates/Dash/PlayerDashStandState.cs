using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashStandState : PlayerDashState
{

    public PlayerDashStandState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();


    }

    public override void Enter()
    {
        base.Enter();

    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (!isGrounded)
            {
                isAbilityDone = true;
            }
            else if (Time.time <= startTime + data.dashStandTime)
            {
                player.MovementOnGround(isSlope, data.dashStandSpeed, player.FacingDirection);
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
    }
    
}
