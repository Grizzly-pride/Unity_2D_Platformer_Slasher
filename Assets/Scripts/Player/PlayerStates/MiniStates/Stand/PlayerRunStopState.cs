using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunStopState : PlayerStandState
{
    public PlayerRunStopState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
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

            if (xInput != 0)
            {
                if (xInputForce >= data.runningThreshold)
                {
                    stateMachine.ChangeState(player.RunState);
                }
                else
                {
                    stateMachine.ChangeState(player.WalckState);
                }
            }
            
            else if (isAnimationFinished)
            {
                stateMachine.ChangeState(player.StandIdleState);
            }
            
        }
    }



}
