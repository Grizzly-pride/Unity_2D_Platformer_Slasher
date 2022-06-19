using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeGrabState : PlayerOnLedgeState
{
    public PlayerLedgeGrabState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }


    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.JumpState.ResetAmountOfJumpsLeft();
        HoldPosition();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        HoldPosition();
        /*
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.LedgeHoldState);
        }
        */
    }
}
