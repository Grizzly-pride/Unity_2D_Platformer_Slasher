using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalckState : PlayerStandState
{
    public PlayerWalckState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
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

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            player.CheckIfShouldFlip(xInput);

            if (xInput == 0)
            {
                stateMachine.ChangeState(player.StandIdleState);

            }
            if(xInputForce >= data.runningThreshold)
            {
                stateMachine.ChangeState(player.RunState);
            }

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();


        if (!isExitingState)
        {
            player.MovementOnGround(isSlope, data.walckSpeed, xInput);
        }
    }
}
