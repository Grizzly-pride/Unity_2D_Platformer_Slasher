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
        player.SetPhysicsMaterial(data.noFrictionMaterial);

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
                applyMotion = true;
            }
            else
            {
                applyMotion = false;    
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

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (applyMotion)
        {
            player.MovementOnGround(isSlope, data.dashStandSpeed, player.FacingDirection);
        }

    }

}
