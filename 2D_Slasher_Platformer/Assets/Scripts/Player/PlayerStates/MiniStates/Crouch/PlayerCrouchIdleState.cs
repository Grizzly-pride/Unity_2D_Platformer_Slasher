using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchIdleState : PlayerCrouchState
{
    public PlayerCrouchIdleState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetPhysicsMaterial(data.frictionMaterial);
        player.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
        player.SetPhysicsMaterial(data.noFrictionMaterial);
    }

    public override void LogicUpdate()
    { 
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (xInput != 0)
            {
                stateMachine.ChangeState(player.CrouchMoveState);
            }

        }                 
    }
}
