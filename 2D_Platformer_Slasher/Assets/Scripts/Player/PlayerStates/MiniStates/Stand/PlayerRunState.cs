using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerStandState
{

    public PlayerRunState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
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
            player.CheckIfShouldFlip(xInput);

            if (xInput == 0)
            {
                stateMachine.ChangeState(player.RunStopState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!isExitingState)
        {
            player.MovementOnGround(isSlope, data.runSpeed, xInput);
        }

    }

}
