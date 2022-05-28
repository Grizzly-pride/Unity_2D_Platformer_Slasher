using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnWallState : PlayerState
{
    public PlayerOnWallState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    private Vector2 holdPosition;

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        holdPosition = player.transform.position;
        HoldPosition();

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
            HoldPosition();
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void HoldPosition()
    {
        player.transform.position = holdPosition;
        player.SetVelocityZero();

    }
}
