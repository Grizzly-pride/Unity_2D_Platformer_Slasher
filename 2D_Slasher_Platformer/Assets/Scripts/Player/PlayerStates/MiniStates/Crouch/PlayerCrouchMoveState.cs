using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchMoveState : PlayerCrouchState
{
    public PlayerCrouchMoveState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        player.SetPhysicsMaterial(data.noFrictionMaterial);
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            player.MovementOnGround(isSlope, data.crouchSpeed, xInput);
            player.CheckIfShouldFlip(xInput);


            if (xInput == 0)
            {
                stateMachine.ChangeState(player.CrouchIdleState);
            }

        }

    }

}
