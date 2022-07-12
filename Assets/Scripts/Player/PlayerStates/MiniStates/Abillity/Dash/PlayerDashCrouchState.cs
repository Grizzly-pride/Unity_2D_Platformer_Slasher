using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashCrouchState : PlayerDashState
{

    public PlayerDashCrouchState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
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
            else if (!isGrounded)
            {
                applyMotion = false;
                isAbilityDone = true;
            }
            else
            {
                lastDashTime = Time.time;

                stateMachine.ChangeState(player.DashToCrouchState);

            }

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (applyMotion)
        {
            player.MovementOnGround(isSlope, data.dashCrouchSpeed, player.FacingDirection);
        }

    }

}
