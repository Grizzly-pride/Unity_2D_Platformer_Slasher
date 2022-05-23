using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerInAirState
{

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        SetDeactivatedCheckGround();
        player.SetVelocityY(data.jumpForce);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();    

        if (dobleJumpInput)
        {
            player.InputController.UseJumpInput();
            stateMachine.ChangeState(player.DoubleJumpState);
        }
        else if (player.currentMotion.y < 0.01f)
        {
            stateMachine.ChangeState(player.FallState);
        }

    }

}
