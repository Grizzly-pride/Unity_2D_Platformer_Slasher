using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashToCrouchState : PlayerGroundedState
{
    public PlayerDashToCrouchState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetPhysicsMaterial(data.frictionMaterial);
        player.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (isAnimationFinished)
            {
                stateMachine.ChangeState(player.CrouchIdleState);
            }

        }

    }
}
