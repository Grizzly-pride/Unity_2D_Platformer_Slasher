using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHardLanding : PlayerGroundedState
{
    public PlayerHardLanding(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetPhysicsMaterial(data.frictionMaterial);
        player.SetVelocityZero();
        player.JumpState.ResetAmountOfJumpsLeft();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (isAnimationFinished)
            {
                stateMachine.ChangeState(player.StandIdleState);
            }
        }

    }


}
