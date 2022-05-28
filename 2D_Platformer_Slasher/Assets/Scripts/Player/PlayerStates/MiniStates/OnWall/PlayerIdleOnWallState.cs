using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleOnWallState : PlayerOnWallState
{
    public PlayerIdleOnWallState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    private bool jumpInput;

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

        if (!isExitingState)
        {
            jumpInput = player.InputController.JumpInput;

            if (jumpInput)
            {
                stateMachine.ChangeState(player.JumpState);
            }

        }

    }




}
