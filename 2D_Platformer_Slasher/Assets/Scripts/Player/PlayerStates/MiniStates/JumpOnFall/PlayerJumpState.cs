using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.InputController.UseJumpInput();
        player.SetVelocityY(data.jumpForce);
        isAbilityDone = true;
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();



    }

    

}
