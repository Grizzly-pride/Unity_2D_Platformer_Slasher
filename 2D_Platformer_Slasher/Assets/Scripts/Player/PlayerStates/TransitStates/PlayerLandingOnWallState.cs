using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandingOnWallState : PlayerOnWallState
{
    public PlayerLandingOnWallState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
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

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleOnWallState);
        }
    }


}
