using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJumpState : PlayerInAirState
{
    public PlayerDoubleJumpState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {  
    }

    public override void Enter()
    {
        base.Enter();
        player.InputController.UseJumpInput();
        SetAactivatedCheckGround();
        player.SetVelocityY(data.doubleJumpForce);
    }


}
